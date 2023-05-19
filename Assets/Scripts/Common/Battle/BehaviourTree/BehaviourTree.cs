using System;
using System.Collections.Generic;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Common.Battle.BehaviourTree
{
    [CreateAssetMenu(menuName = "Battle / Behaviour / Tree", fileName = "BehaviourTree")]
    public class BehaviourTree : ScriptableObject
    {
        [SerializeField] private Blackboard _blackboard = new Blackboard();
        
        [HideInInspector] [SerializeField] private List<Node> _nodes = new List<Node>();
        [HideInInspector] [SerializeField] private Node _rootNode;

        private Enums.BehaviourNodeState _treeState = Enums.BehaviourNodeState.Running;

        public List<Node> Nodes => _nodes;
        public Node RootNode => _rootNode;
        public Blackboard Blackboard => _blackboard;

        public Enums.BehaviourNodeState Update()
        {
            if (RootNode.State == Enums.BehaviourNodeState.Running)
                _treeState = RootNode.UpdateCurrentState();

            return _treeState;
        }

        public void SetRootNode(Node rootNode) => _rootNode = rootNode;

        public void Bind(IUnitData unitData)
        {
            Traverse(_rootNode, n =>
            {
                n.SetBlackboard(_blackboard);
                n.SetUnitData(unitData);
            });
        }
        
        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            RootNode clone = tree.RootNode.Clone() as RootNode;
            
            tree.SetRootNode(clone);
            tree._nodes = new List<Node>();
            
            Traverse(tree.RootNode, (n) =>
            {
                tree._nodes.Add(n);
            });

            return tree;
        }
        
        public List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();
            
            RootNode root = parent as RootNode;
            
            if (root && root.ChildNode)
                children.Add(root.ChildNode);

            DecoratorNode decorator = parent as DecoratorNode;
            
            if (decorator && decorator.ChildNode)
                children.Add(decorator.ChildNode);
            
            CompositeNode composite = parent as CompositeNode;
            
            if (composite)
                return composite.ChildNodes;

            return children;
        }
        
        private void Traverse(Node node, Action<Node> visitor)
        {
            if (node)
            {
                visitor?.Invoke(node);

                List<Node> children = GetChildren(node);
                
                children.ForEach((n) => Traverse(n, visitor));
            }
        }
        
#if UNITY_EDITOR
        public Node CreateNode(Type type)
        {
            Node node = CreateInstance(type) as Node;
            node.name = type.Name;
            
            node.SetGUID(GUID.Generate().ToString());
            
            Undo.RecordObject(this, "Behaviour Tree View(Create Node)");
            
            _nodes.Add(node);

            if (Application.isPlaying == false)
            {
                AssetDatabase.AddObjectToAsset(node, this);
                EditorUtility.SetDirty(this);
            }
            
            Undo.RegisterCreatedObjectUndo(node, "Behaviour Tree View(Create Node)");
            
            AssetDatabase.SaveAssets();

            return node;
        }

        public void DeleteNode(Node node)
        {
            if (_nodes.Contains(node))
            {
                Undo.RecordObject(this, "Behaviour Tree View(Delete Node)");
                
                _nodes.Remove(node);
                
                Undo.DestroyObjectImmediate(node);
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }
        }

        public void AddChild(Node parent, Node child)
        {
            RootNode root = parent as RootNode;
            
            if (root)
            {
                Undo.RecordObject(root, "Behaviour Tree View(Add Child)");
                root.AddChild(child);
                EditorUtility.SetDirty(root);
            }
            
            DecoratorNode decorator = parent as DecoratorNode;
            
            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree View(Add Child)");
                decorator.AddChild(child);
                EditorUtility.SetDirty(decorator);
            }
            
            CompositeNode composite = parent as CompositeNode;
            
            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree View(Add Child)");
                composite.AddChild(child);
                EditorUtility.SetDirty(composite);
            }
        }

        public void RemoveChild(Node parent, Node child)
        {
            RootNode root = parent as RootNode;
            
            if (root)
            {
                Undo.RecordObject(root, "Behaviour Tree View(Remove Child)");
                root.RemoveChild();
                EditorUtility.SetDirty(root);
            }
            
            DecoratorNode decorator = parent as DecoratorNode;
            
            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree View(Remove Child)");
                decorator.RemoveChild();
                EditorUtility.SetDirty(decorator);
            }
            
            CompositeNode composite = parent as CompositeNode;
            
            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree View(Remove Child)");
                composite.RemoveChild(child);
                EditorUtility.SetDirty(composite);
            }
        }
#endif
    }
}