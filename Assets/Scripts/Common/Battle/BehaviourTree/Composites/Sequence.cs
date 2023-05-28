using Infrastructure.Utils;

namespace Common.Battle.BehaviourTree.Composites
{
    public class Sequence : CompositeNode
    {
        private int _index;
        
        protected override void Start() 
        {
            _index = 0;
        }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            Node child = ChildNodes[_index];

            switch (child.UpdateCurrentState())
            {
                case Enums.BehaviourNodeState.Running:
                    return Enums.BehaviourNodeState.Running;

                case Enums.BehaviourNodeState.Failure:
                    return Enums.BehaviourNodeState.Failure;
                
                case Enums.BehaviourNodeState.Success:
                    _index++;
                    break;
            }

            return _index == ChildNodes.Count 
                ? Enums.BehaviourNodeState.Success 
                : Enums.BehaviourNodeState.Running;
        }
    }
}