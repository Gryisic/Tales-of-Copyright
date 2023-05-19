using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree.Actions
{
    public class ExecuteAction : ActionNode
    {
        private bool _executed;

        protected override void Start()
        {
            _executed = false;
        }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            if (_executed == false && unitData.ActionHandler.CurrentAction == null)
            {
                _executed = true;

                Vector2 direction = (blackboard.Target.transform.position - unitData.Rigidbody2D.transform.position).normalized;
                Rotate(direction);
                
                blackboard.CashedAction.RequestExecution();
                blackboard.ClearAction();
                blackboard.SetTarget(null);
                
                unitData.DirectionHandler.Update(Vector2.zero);
            }
            else if (_executed && unitData.ActionHandler.CurrentAction == null)
            {
                float awaitTime = Time.time + Random.Range(2, 4) + unitData.Animator.DurationOfCurrentAnimation;
                
                blackboard.SetAwaitTime(awaitTime);
                
                return Enums.BehaviourNodeState.Success;
            }

            return Enums.BehaviourNodeState.Running;
        }
        
        private void Rotate(Vector2 direction)
        {
            float rotationAngle = direction.x >= 0 ? 0f : 180f;

            unitData.Rigidbody2D.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}