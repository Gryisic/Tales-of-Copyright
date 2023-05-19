using System;
using System.Collections.Generic;
using System.Linq;
using Common.Factories;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.States
{
    public class InitializeState : BattleState
    {
        private readonly BattleArgs _args;
        private UnitsContainer _unitsContainer;
        
        public InitializeState(BattleArgs args, UnitsContainer unitsContainer, Battle battle) : base(battle)
        {
            _args = args;
            _unitsContainer = unitsContainer;
        }

        public override void Enter()
        {
            InitializeAsync().Forget();
        }

        public override void Exit() { }

        private void InitializeUnits()
        {
            _unitsContainer.PartyMembers.ForEach(u =>
            {
                u.Initialize(_unitsContainer.All, battle.ProjectilePool, battle.TargetSelector);
            });

            _unitsContainer.Enemies.ForEach(u =>
            {
                u.Initialize(_unitsContainer.All, battle.ProjectilePool, battle.TargetSelector);
            });
        }
        
        private void CreatePartyMembers(IReadOnlyDictionary<Enums.PartyMemberType, Vector2> positions)
        {
            IPartyMemberFactory unitFactory = new PartyMemberFactory();
            unitFactory.Load(positions.Keys.ToList());
            
            foreach (var position in positions)
            {
                unitFactory.Create(position.Key, position.Value, out PartyMember unit);
                
                _unitsContainer.AddUnit(unit);
            }
        }
        
        private void CreateEnemies(IReadOnlyCollection<SpawnPoint> spawnPoints)
        {
            IEnemyFactory unitFactory = new EnemyFactory();
            
            foreach (var point in spawnPoints)
            {
                unitFactory.Create(point.Enemy, point.Position, out Enemy unit);
                
                _unitsContainer.AddUnit(unit);
            }
        }
        
        private async UniTask InitializeAsync()
        {
            _args.PartyData.Placement.SetInitialPartyPosition(_args.SpawnPointsTemplate.PartySide);

            CreatePartyMembers(_args.PartyData.Placement.UnitPlacementMap);
            CreateEnemies(_args.SpawnPointsTemplate.SpawnPoints);
            InitializeUnits();
            
            await UniTask.Delay(TimeSpan.FromSeconds(Constants.BattleInitiationTime));

            battle.BattleUI.Initialize(_unitsContainer.PartyMembers);
            battle.Camera.Activate(_unitsContainer.PartyMembers[0]);

            _unitsContainer.All.ForEach(u => u.ActivateBehaviour());

            StateSwitcher.ChangeState<GameplayState>();
        }
    }
}