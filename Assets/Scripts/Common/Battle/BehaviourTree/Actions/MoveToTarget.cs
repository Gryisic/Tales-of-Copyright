using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree.Actions
{
    public class MoveToTarget : ActionNode
    {
        private Transform _targetTransform;
        private Transform _unitTransform;

        protected override void Start()
        {
            if (_unitTransform == null)
                _unitTransform = unitData.Rigidbody2D.transform;
            
            _targetTransform = null;
        }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            if (blackboard.Target != null && blackboard.CashedAction != null)
            {
                if (_targetTransform == null)
                    _targetTransform = blackboard.Target.transform;

                Vector2 delta = _targetTransform.position - _unitTransform.position;
                Vector2 direction = delta.normalized;
                float distance = Mathf.Abs(delta.magnitude);
                
                direction.y = 0;

                if (distance <= blackboard.CashedAction.ExecutionDistance)
                    unitData.DirectionHandler.Update(Vector2.zero);
                else
                    unitData.DirectionHandler.Update(direction);

                return Enums.BehaviourNodeState.Success;
            }

            unitData.DirectionHandler.Update(Vector2.zero);
            
            return Enums.BehaviourNodeState.Running;
        }
    }
}