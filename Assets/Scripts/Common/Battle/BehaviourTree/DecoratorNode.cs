using UnityEngine;
using UnityEngine.Serialization;

namespace Common.Battle.BehaviourTree
{
    public abstract class DecoratorNode : Node
    {
        [HideInInspector] [SerializeField] protected Node childNode;

        public Node ChildNode => childNode;

        public void AddChild(Node node) => childNode = node;

        public void RemoveChild() => childNode = null;
        
        public override Node Clone()
        {
            DecoratorNode node = Instantiate(this);
            node.AddChild(ChildNode.Clone());

            return node;
        }
    }
}