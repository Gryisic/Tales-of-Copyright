using System;
using System.Linq;
using Common.Battle.States;
using Common.Models.Units;
using Infrastructure.Interfaces;
using Common.Battle.TargetSelector;
using Common.Data;
using Common.Models.Camera;
using Common.StateMachines;
using Common.UI.Battle;
using Core.Input;
using Infrastructure.Extensions;

namespace Common.Battle
{
    public class Battle : IStateSwitcher, IDisposable
    {
        public event Action<bool> Paused;
        public event Action Ended;

        private ImpactEffects _impactEffects = new ImpactEffects();
        
        private BattleState[] _states;
        private BattleState _currentState;
        
        private PartyData _partyData;

        public ProjectilePool ProjectilePool { get; private set; } = new ProjectilePool();
        public UnitsContainer UnitsContainer { get; private set; } = new UnitsContainer();

        public TargetSelectionArgs TargetSelectionArgs { get; private set; }
        public TargetSelector.TargetSelector TargetSelector { get; private set; }

        public PlayerInput Input { get; }
        public BattleCamera Camera { get; }
        public BattleUI BattleUI { get; }

        public Battle(BattleArgs args, PlayerInput input)
        {
            Input = input;
            Camera = args.Camera;
            BattleUI = args.UI;

            Initiate(args);
        }

        private void Initiate(BattleArgs args)
        {
            _states = new BattleState[]
            {
                new InitializeState(args, UnitsContainer, this),
                new GameplayState(this),
                new TargetSelectionState(this),
                new WinState(this),
                new LoseState(this)
            };

            TargetSelector = new TargetSelector.TargetSelector(UnitsContainer.All);

            ChangeState<InitializeState>();

            _partyData = args.PartyData;
            _partyData.UpdatePlayerUnit(UnitsContainer.PartyMembers[0]);
            
            SubscribeToEvents();
        }

        public void Dispose()
        {
            UnsubscribeToEvents();
            
            UnitsContainer.All.ForEach(u => u.Dispose());
        }

        public void SelectLeft() => _currentState.SelectLeft();
        
        public void SelectRight() => _currentState.SelectRight();
        
        public void Select() => _currentState.Select();
        
        public void Cancel() => _currentState.UndoSelection();
        
        public void ChangeState<T>() where T : State
        {
            _currentState?.Exit();

            _currentState = _states.First(s => s is T);
            
            _currentState.Enter();
        }
        
        public void EnterTargetSelectionState(TargetSelectionArgs targetSelectionArgs)
        {
            TargetSelectionArgs = targetSelectionArgs;

            ChangeState<TargetSelectionState>();
        }

        private void Pause() => Paused?.Invoke(true);

        private void Continue() => Paused?.Invoke(false);
        
        private void Win() => ChangeState<WinState>();

        private void Lose() => ChangeState<LoseState>();

        private void RaiseEndedEvent() => Ended?.Invoke();

        private void SubscribeToEvents()
        {
            Paused += Camera.ChangeUpdateMethod;
            
            UnitsContainer.ContainerModified += TargetSelector.UpdatePossibleTargets;
            UnitsContainer.PartyMembersDead += Lose;
            UnitsContainer.EnemiesDead += Win;

            WinState winState = _states.First(s => s is WinState) as WinState;
            winState.Ended += RaiseEndedEvent;

            foreach (var state in _states)
            {
                if (state is IPauseProvider pauseProvider)
                {
                    pauseProvider.RequestPause += Pause;
                    pauseProvider.EndPause += Continue;
                }
            }
            
            foreach (var unit in UnitsContainer.All)
            {
                unit.DamageTaken += ImpactUnitDamage;
                unit.Died += UnitsContainer.Remove;
                
                if (unit is PartyMember partyMember)
                {
                    partyMember.HealthChanged += BattleUI.UpdatePartyMemberHealth;
                    partyMember.EnergyChanged += BattleUI.UpdatePartyMemberEnergy;
                    partyMember.DamageTaken += BattleUI.ShakePartyMemberStatus;
                }
            }
        }

        private void UnsubscribeToEvents()
        {
            Paused -= Camera.ChangeUpdateMethod;
            
            UnitsContainer.ContainerModified -= TargetSelector.UpdatePossibleTargets;
            UnitsContainer.PartyMembersDead -= Lose;
            UnitsContainer.EnemiesDead -= Win;
            
            WinState winState = _states.First(s => s is WinState) as WinState;
            winState.Ended -= RaiseEndedEvent;
            
            foreach (var state in _states)
            {
                if (state is IPauseProvider pauseProvider)
                {
                    pauseProvider.RequestPause -= Pause;
                    pauseProvider.EndPause -= Continue;
                }
            }
            
            foreach (var unit in UnitsContainer.All)
            {
                unit.DamageTaken -= ImpactUnitDamage;
                unit.Died -= UnitsContainer.Remove;
                
                if (unit is PartyMember partyMember)
                {
                    partyMember.HealthChanged -= BattleUI.UpdatePartyMemberHealth;
                    partyMember.EnergyChanged -= BattleUI.UpdatePartyMemberEnergy;
                    partyMember.DamageTaken -= BattleUI.ShakePartyMemberStatus;
                }
            }
        }
        
        private void ImpactUnitDamage(IDamagable damagable, int value)
        {
            _impactEffects.StopTimeOnHit();
        }

        // private void UpdatePartyPosition(InputAction.CallbackContext context) => 
        //     _partyData.Placement.UpdatePartyPosition(_player.ControllableUnit.transform);
        //
        // private void StopUpdatingPosition(InputAction.CallbackContext context) => 
        //     _partyData.Placement.StopUpdatingPosition();
    }
}