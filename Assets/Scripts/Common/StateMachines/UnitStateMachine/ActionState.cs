using System;
using System.Threading;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.StateMachines.UnitStateMachine
{
    public class ActionState : UnitState, IUnitActionExecutable
    {
        public event Action ActionExecuted;
        public event Action ActionCancelled;

        public ActionState(Unit unit, IStateSwitcher stateSwitcher) : base(unit, stateSwitcher) { }

        public override void Enter()
        {
            TokenSource = TokenSource.CancelAndRefresh();
            
            Unit.Animator.Play(Unit.ActionHandler.CurrentAction.Animation);

            ExecuteAsync().Forget();
        }

        public override void Exit()
        {
            
        }

        public override void Cancel()
        {
            ActionCancelled?.Invoke();
            
            TokenSource.Cancel();
        }

        private async UniTask ExecuteAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            float duration = Unit.Animator.DurationOfCurrentAnimation - 0.1f;
            
            UniTask awaitForAnimationEndTask = UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: TokenSource.Token);
            UniTask awaitCancellationTask = UniTask.WaitUntilCanceled(TokenSource.Token);

            await UniTask.WhenAny(awaitForAnimationEndTask, awaitCancellationTask);

            ActionExecuted?.Invoke();

            Unit.Animator.Pause();
            
            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: TokenSource.Token);
            
            Unit.Animator.Continue();

            StateSwitcher.ChangeState<NeutralState>();
        }
    }
}