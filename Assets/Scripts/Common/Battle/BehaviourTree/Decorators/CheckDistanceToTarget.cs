using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree.Decorators
{
    public class CheckDistanceToTarget : DecoratorNode
    {
        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            if (blackboard.Target == null || blackboard.CashedAction == null) 
                return Enums.BehaviourNodeState.Failure;
            
            float distance = Mathf.Abs((blackboard.Target.Rigidbody2D.position - unitData.Rigidbody2D.position).magnitude);

            if (distance > blackboard.CashedAction.ExecutionDistance) 
                return Enums.BehaviourNodeState.Failure;
            
            unitData.DirectionHandler.Update(Vector2.zero);  
            childNode.UpdateCurrentState();
            
            return Enums.BehaviourNodeState.Success;

        }
    }
}