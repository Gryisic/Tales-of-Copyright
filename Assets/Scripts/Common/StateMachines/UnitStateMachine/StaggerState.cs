using System;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.StateMachines.UnitStateMachine
{
    public class StaggerState : UnitState
    {
        private readonly Unit _unit;

        private bool _alreadyStaggered;
        
        public StaggerState(Unit unit, IStateSwitcher stateSwitcher) : base(unit, stateSwitcher)
        {
            _unit = unit;
        }

        public override void Enter()
        {
            _unit.UpdateStaggerState(true);
            
            TokenSource = TokenSource.CancelAndRefresh();
            
            _unit.DirectionHandler.Update(Vector2.zero);
            StaggerAsync().Forget();
        }

        public override void Exit()
        {
            _unit.UpdateStaggerState(false);
            _unit.Animator.Continue();
        }
        
        public override void Cancel()
        {
            TokenSource.Cancel();
        }

        private async UniTask StaggerAsync()
        {
            if (_alreadyStaggered == false)
            {
                _alreadyStaggered = true;
                
                _unit.Animator.Play(Constants.TakeDamageInName, isLooped: false);
                
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: TokenSource.Token);
                
                float durationIn = _unit.Animator.DurationOfCurrentAnimation - 0.1f;

                await UniTask.Delay(TimeSpan.FromSeconds(durationIn), cancellationToken: TokenSource.Token);
            }

            _unit.Animator.Pause();
            
            await UniTask.Delay(TimeSpan.FromSeconds(0.8f), cancellationToken: TokenSource.Token);

            _alreadyStaggered = false;
            
            _unit.Animator.Continue();

            if (_unit.IsAlive)
                StateSwitcher.ChangeState<NeutralState>();
        }
    }
}