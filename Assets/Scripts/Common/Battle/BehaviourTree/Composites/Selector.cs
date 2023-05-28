using Infrastructure.Utils;

namespace Common.Battle.BehaviourTree.Composites
{
    public class Selector : CompositeNode
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
                
                case Enums.BehaviourNodeState.Success:
                    return Enums.BehaviourNodeState.Success;

                case Enums.BehaviourNodeState.Failure:
                    _index++;
                    break;
            }

            return _index == ChildNodes.Count 
                ? Enums.BehaviourNodeState.Failure 
                : Enums.BehaviourNodeState.Running;
        }
    }
}