using System.Collections.Generic;
using UnityEngine;

namespace Common.Battle.BehaviourTree
{
    public abstract class CompositeNode : Node
    {
        [SerializeField] protected List<Node> childNodes = new List<Node>();

        public List<Node> ChildNodes => childNodes;

        public void AddChild(Node node) => childNodes.Add(node);

        public void RemoveChild(Node node)
        {
            if (childNodes.Contains(node))
                childNodes.Remove(node);
        }

        public void SortChildren()
        {
            childNodes.Sort(SortByHorizontalPosition);
        }
        
        public override Node Clone()
        {
            CompositeNode node = Instantiate(this);
            node.childNodes = childNodes.ConvertAll(c => c.Clone());

            return node;
        }
        
        private int SortByHorizontalPosition(Node left, Node right) => left.Position.x < right.Position.x ? -1 : 1;
    }
}