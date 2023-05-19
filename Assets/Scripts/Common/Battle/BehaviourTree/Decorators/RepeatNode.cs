using Infrastructure.Utils;

namespace Common.Battle.BehaviourTree.Decorators
{
    public class RepeatNode : DecoratorNode
    {
        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            childNode.UpdateCurrentState();

            return Enums.BehaviourNodeState.Running;
        }
    }
}