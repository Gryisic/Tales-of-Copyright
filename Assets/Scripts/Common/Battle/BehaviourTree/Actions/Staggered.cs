using Infrastructure.Utils;

namespace Common.Battle.BehaviourTree.Actions
{
    public class Staggered : ActionNode
    {
        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update() => unitData.IsStaggered ? Enums.BehaviourNodeState.Failure : Enums.BehaviourNodeState.Success;
    }
}