#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Battle.BehaviourTree;
using Infrastructure.Utils;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using Node = Common.Battle.BehaviourTree.Node;

public class BehaviourTreeView : GraphView
{
    public new class UxmlFactory: UxmlFactory<BehaviourTreeView, UxmlTraits> { }
    
    public Action<BehaviourNodeView> NodeSelected; 

    private BehaviourTree _behaviourTree;

    public BehaviourTreeView()
    {
        Insert(0, new GridBackground());
        
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(Constants.PathToBehaviourTreeEditorUSS);
        styleSheets.Add(styleSheet);
        
        Undo.undoRedoPerformed += UndoRedo;
    }

    public void PopulateView(BehaviourTree tree)
    {
        _behaviourTree = tree;

        graphViewChanged -= GraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += GraphViewChanged;

        if (_behaviourTree.RootNode == null)
        {
            RootNode node = _behaviourTree.CreateNode(typeof(RootNode)) as RootNode;
            
            _behaviourTree.SetRootNode(node);
            
            EditorUtility.SetDirty(_behaviourTree);
            AssetDatabase.SaveAssets();
        }
        
        _behaviourTree.Nodes.ForEach(CreateNodeView);
        
        _behaviourTree.Nodes.ForEach(n =>
        {
            List<Node> children = _behaviourTree.GetChildren(n);
            
            children.ForEach(c =>
            {
                BehaviourNodeView parentView = FindNodeView(n);
                BehaviourNodeView childView = FindNodeView(c);
                
                Edge edge = parentView.OutPort.ConnectTo(childView.InPort);
                AddElement(edge);
            });
        });
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        {
            TypeCache.TypeCollection types = TypeCache.GetTypesDerivedFrom<ActionNode>();

            foreach (var type in types)
                evt.menu.AppendAction($"{type.BaseType.Name} / {type.Name}", (a) => CreateNode(type));
        }
        
        {
            TypeCache.TypeCollection types = TypeCache.GetTypesDerivedFrom<CompositeNode>();

            foreach (var type in types)
                evt.menu.AppendAction($"{type.BaseType.Name} / {type.Name}", (a) => CreateNode(type));
        }
        
        {
            TypeCache.TypeCollection types = TypeCache.GetTypesDerivedFrom<DecoratorNode>();

            foreach (var type in types)
                evt.menu.AppendAction($"{type.BaseType.Name} / {type.Name}", (a) => CreateNode(type));
        }
    }
    
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        return ports.ToList()
            .Where(endPort => endPort.direction != startPort.direction && endPort.node != startPort.node)
            .ToList();
    }

    public void UpdateNodeState()
    {
        nodes.ForEach((n) =>
        {
            BehaviourNodeView view = n as BehaviourNodeView;
            
            view.UpdateState();
        });
    }

    private BehaviourNodeView FindNodeView(Node node) => GetNodeByGuid(node.GUID) as BehaviourNodeView;
    
    private GraphViewChange GraphViewChanged(GraphViewChange graphViewChange)
    {
        if (graphViewChange.elementsToRemove != null)
        {
            graphViewChange.elementsToRemove.ForEach(element =>
            {
                if (element is BehaviourNodeView nodeView)
                    _behaviourTree.DeleteNode(nodeView.Node);

                if(element is Edge edge)
                    if (edge.output.node is BehaviourNodeView parentView 
                        && edge.input.node is BehaviourNodeView childView)
                        _behaviourTree.RemoveChild(parentView.Node, childView.Node);
            });
        }
        
        if (graphViewChange.edgesToCreate != null)
        {
            graphViewChange.edgesToCreate.ForEach(edge =>
            {
                if (edge.output.node is BehaviourNodeView parentView 
                    && edge.input.node is BehaviourNodeView childView)
                    _behaviourTree.AddChild(parentView.Node, childView.Node);
            });
        }

        if (graphViewChange.movedElements != null)
        {
            nodes.ForEach((n) =>
            {
                BehaviourNodeView nodeView = n as BehaviourNodeView;
                
                nodeView.SortChildren();
            });
        }
        
        return graphViewChange;
    }

    private void CreateNode(Type type)
    {
        Node node = _behaviourTree.CreateNode(type);
        
        CreateNodeView(node);
    }
    
    private void CreateNodeView(Node node)
    {
        BehaviourNodeView view = new BehaviourNodeView(node);
        view.NodeSelected = NodeSelected;
        
        AddElement(view);
    }

    private void UndoRedo()
    {
        PopulateView(_behaviourTree);
        AssetDatabase.SaveAssets();
    }
}
#endif