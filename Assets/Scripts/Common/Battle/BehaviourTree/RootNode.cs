using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree
{
    public class RootNode : Node
    {
        [HideInInspector] [SerializeField] private Node _childNode;

        public Node ChildNode => _childNode;

        public void AddChild(Node child) => _childNode = child;

        public void RemoveChild() => _childNode = null;

        public override Node Clone()
        {
            RootNode node = Instantiate(this);
            node.AddChild(ChildNode.Clone());

            return node;
        }

        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update() => ChildNode.UpdateCurrentState();
    }
}