#if UNITY_EDITOR
using System;
using Common.Battle.BehaviourTree;
using Infrastructure.Utils;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Node = Common.Battle.BehaviourTree.Node;

public class BehaviourNodeView : UnityEditor.Experimental.GraphView.Node
{
    public Action<BehaviourNodeView> NodeSelected;

    private Node _node;
    private Port _inPort;
    private Port _outPort;

    public Node Node => _node;
    public Port InPort => _inPort;
    public Port OutPort => _outPort;
    
    public BehaviourNodeView(Node node) : base(Constants.PathToBehaviourNodeUXML)
    {
        _node = node;
        title = node.name;
        viewDataKey = node.GUID;

        style.left = node.Position.x;
        style.top = node.Position.y;
        
        CreateInputPorts();
        CreateOutputPorts();
        SetupUSSClasses();
        SetLabel();
    }

    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        
        Undo.RecordObject(_node, "Behaviour Tree View(Set Position)");

        Vector2 position = new Vector2(newPos.xMin, newPos.yMin);
        
        Node.SetPosition(position);
        EditorUtility.SetDirty(_node);
    }

    public override void OnSelected()
    {
        base.OnSelected();
        
        NodeSelected?.Invoke(this);
    }

    public void SortChildren()
    {
        CompositeNode node = _node as CompositeNode;
        
        if (node)
            node.SortChildren();
    }

    public void UpdateState()
    {
        RemoveFromClassList("running");
        RemoveFromClassList("success");
        RemoveFromClassList("failure");

        if (Application.isPlaying == false)
            return;
        
        switch (_node.State)
        {
            case Enums.BehaviourNodeState.Running:
                if (Node.IsStarted)
                    AddToClassList("running");
                break;
            
            case Enums.BehaviourNodeState.Success:
                AddToClassList("success");
                break;
            
            case Enums.BehaviourNodeState.Failure:
                AddToClassList("failure");
                break;
        }
    }

    private void CreateInputPorts()
    {
        switch (Node)
        {
            case ActionNode _:
                _inPort = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
                break;
            
            case DecoratorNode _:
                _inPort = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
                break;
            
            case CompositeNode _:
                _inPort = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
                break;
            
            case RootNode _:
                break;
        }

        if (InPort != null)
        {
            InPort.portName = String.Empty;
            InPort.style.flexDirection = FlexDirection.Column;
            inputContainer.Add(InPort);
        }
    }
    
    private void CreateOutputPorts()
    {
        switch (Node)
        {
            case ActionNode _:
                break;
            
            case DecoratorNode _:
                _outPort = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
                break;
            
            case CompositeNode _:
                _outPort = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(bool));
                break;
            
            case RootNode _:
                _outPort = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
                break;
        }
        
        if (OutPort != null)
        {
            OutPort.portName = String.Empty;
            OutPort.style.flexDirection = FlexDirection.ColumnReverse;
            outputContainer.Add(OutPort);
        }
    }

    private void SetupUSSClasses()
    {
        switch (Node)
        {
            case ActionNode _:
                AddToClassList("action");
                break;
            
            case DecoratorNode _:
                AddToClassList("decorator");
                break;
            
            case CompositeNode _:
                AddToClassList("composite");         
                break;
            
            case RootNode _:
                AddToClassList("root");   
                break;
        }
    }
    
    private void SetLabel()
    {
        Label descriptionLabel = this.Q<Label>("description");
        descriptionLabel.bindingPath = "_description";
        descriptionLabel.Bind(new SerializedObject(_node));
    }
}
#endif