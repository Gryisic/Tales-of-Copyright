using Common.Models.Sugar;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.StateMachines.UnitStateMachine
{
    public class NeutralState : UnitState
    {
        private readonly DirectionHandler _directionHandler;

        public NeutralState(Unit unit, IStateSwitcher stateSwitcher) : base(unit, stateSwitcher)
        {
            _directionHandler = unit.DirectionHandler;
        }

        public override void Enter()
        {
            TokenSource = TokenSource.CancelAndRefresh();
            
            Unit.Animator.Play(Constants.IdleName, true);
            
            IdleAsync().Forget();
        }

        public override void Exit()
        {
            
        }
        
        public override void Cancel()
        {
            TokenSource = TokenSource.CancelAndRefresh();
        }

        private async UniTask IdleAsync()
        {
            await UniTask.Yield();
            
            while (TokenSource.IsCancellationRequested == false)
            {
                if (Unit.ActionHandler.CurrentAction != null)
                {
                    StateSwitcher.ChangeState<ActionState>();
                    return;
                }

                if (_directionHandler.HorizontalDirection != Vector2.zero && _directionHandler.VerticalDirection == Vector2.zero)
                {
                    StateSwitcher.ChangeState<MoveState>();
                    return;
                }

                await UniTask.WaitForFixedUpdate();
            }
        }
    }
}