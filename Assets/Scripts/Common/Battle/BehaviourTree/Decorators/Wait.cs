using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree.Decorators
{
    public class Wait : DecoratorNode
    {
        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            if (blackboard.AwaitTime != 0)
            {
                if (Time.time < blackboard.AwaitTime)
                    return Enums.BehaviourNodeState.Failure;
                
                blackboard.SetAwaitTime(0);

                return Enums.BehaviourNodeState.Success;

            }

            childNode.UpdateCurrentState();
            
            return Enums.BehaviourNodeState.Running;
        }
    }
}