using Infrastructure.Utils;

namespace Common.Battle.BehaviourTree.Decorators
{
    public class AwaitPlayerCommand : DecoratorNode
    {
        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            if (blackboard.Target != null && blackboard.CashedAction != null)
            {
                childNode.UpdateCurrentState();
                
                return Enums.BehaviourNodeState.Success;
            }

            return Enums.BehaviourNodeState.Failure;
        }
    }
}