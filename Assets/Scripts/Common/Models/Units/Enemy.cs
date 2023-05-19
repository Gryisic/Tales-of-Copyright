using System.Collections.Generic;
using Common.Battle;
using Common.Battle.TargetSelector;
using Common.Models.BattleActions;
using Common.Models.StatSystem;
using UnityEngine;

namespace Common.Models.Units
{
    public class Enemy : Unit
    {
        [SerializeField] private EnemyConfig _config;
        
        public override void Initialize(IReadOnlyList<Unit> unitsInBattle, ProjectilePool projectilePool, TargetSelector targetSelector)
        {
            _config = _config.Clone() as EnemyConfig;
            
            Stats = new Stats(_config.StatsTemplate.GetValues());

            actionsHandler = new ActionHandler();
            
            actionsHandler.SetContainer(_config.ActionsContainer);
            actionsHandler.Container.Initialize(this, projectilePool);
            
            base.Initialize(unitsInBattle, projectilePool, targetSelector);
        }
    }
}