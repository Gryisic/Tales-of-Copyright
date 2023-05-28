using Common.Models.Sugar;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.StateMachines.UnitStateMachine
{
    public class MoveState : UnitState
    {
        private const float MovementSpeed = 3f;

        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly DirectionHandler _directionHandler;

        public MoveState(Unit unit, IStateSwitcher stateSwitcher) : base(unit, stateSwitcher)
        {
            _transform = unit.transform;
            _rigidbody2D = unit.Rigidbody2D;
            _directionHandler = unit.DirectionHandler;
        }

        public override void Enter()
        {
            TokenSource = TokenSource.CancelAndRefresh();
            
            Unit.Animator.Play(Constants.MoveName, true);

            MoveAsync().Forget();
        }

        public override void Exit() { }

        public override void Cancel()
        {
            TokenSource.Cancel();
        }
        
        private async UniTask MoveAsync()
        {
            int initialHorizontalDirectionX = (int) _directionHandler.HorizontalDirection.x;
            
            Rotate(_directionHandler.HorizontalDirection);

            while (TokenSource.IsCancellationRequested == false)
            {
                Vector2 direction = _directionHandler.HorizontalDirection;
                
                _rigidbody2D.MovePosition((Vector2) _transform.position + direction
                                                    * Time.fixedDeltaTime * MovementSpeed);

                direction = _directionHandler.Direction;

                if (Unit.ActionHandler.CurrentAction != null)
                {
                    StateSwitcher.ChangeState<ActionState>();
                    return;
                }

                if (direction == Vector2.zero || (int) direction.x != initialHorizontalDirectionX || direction.y != 0)
                {
                    StateSwitcher.ChangeState<NeutralState>();
                    return;
                }
                
                await UniTask.WaitForFixedUpdate();
            }

            TokenSource = TokenSource.CancelAndRefresh();
        }

        private void Rotate(Vector2 direction)
        {
            float rotationAngle = direction.x >= 0 ? 0f : 180f;

            _transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}