using System;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.StateMachines.UnitStateMachine
{
    public class DeathState : UnitState
    {
        public DeathState(Unit unit, IStateSwitcher stateSwitcher) : base(unit, stateSwitcher) { }

        public override void Enter()
        {
            Unit.DeactivateBehaviour();
            Unit.DirectionHandler.Update(Vector2.zero);
            Unit.Animator.Play(Constants.DeathName);
            
            DieAsync().Forget();
        }

        public override void Exit() { }

        public override void Cancel() { }

        private async UniTask DieAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(Unit.Animator.DurationOfCurrentAnimation));
            
            Unit.Animator.Play(Constants.DeathLoopName);
        }
    }
}