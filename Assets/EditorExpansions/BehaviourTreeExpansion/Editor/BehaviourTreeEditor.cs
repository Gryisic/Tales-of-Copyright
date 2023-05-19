#if UNITY_EDITOR
using Common.Battle.BehaviourTree;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class BehaviourTreeEditor : EditorWindow
{
    private BehaviourTreeView _behaviourTreeView;
    private InspectorView _inspectorView;
    private IMGUIContainer _blackboardView;

    private SerializedObject _treeObject;
    private SerializedProperty _blackboardProperty;
    
    [MenuItem("BehaviourTreeEditor / Editor")]
    public static void OpenWindow()
    {
        BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
        wnd.titleContent = new GUIContent("BehaviourTreeEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceID, int line)
    {
        if (Selection.activeObject is BehaviourTree == false) 
            return false;
        
        OpenWindow();
        return true;
    }

    private void OnEnable()
    {
        EditorApplication.playModeStateChanged -= PlayModeStateChanged;
        EditorApplication.playModeStateChanged += PlayModeStateChanged;
    }

    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= PlayModeStateChanged;
    }

    private void OnInspectorUpdate()
    {
        _behaviourTreeView?.UpdateNodeState();
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(Constants.PathToBehaviourTreeEditorUXML);
        visualTree.CloneTree(root);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(Constants.PathToBehaviourTreeEditorUSS);
        root.styleSheets.Add(styleSheet);

        _behaviourTreeView = root.Q<BehaviourTreeView>();
        _inspectorView = root.Q<InspectorView>();
        _blackboardView = root.Q<IMGUIContainer>();

        _blackboardView.onGUIHandler = () =>
        {
            if (_treeObject != null)
            {
                _treeObject.Update();
                EditorGUILayout.PropertyField(_blackboardProperty);
                _treeObject.ApplyModifiedProperties();
            }
        };

        _behaviourTreeView.NodeSelected = OnNodeSelectionChange;
        
        OnSelectionChange();
    }

    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;

        if (tree == null)
        {
            if (Selection.activeGameObject)
            {
                if (Selection.activeGameObject.TryGetComponent(out IBehaviourTreeProvider provaider))
                {
                    tree = provaider.Tree;
                }
            }
        }

        if (Application.isPlaying)
        {
            if (tree)
                _behaviourTreeView.PopulateView(tree);
        }
        else
        {
            if (_behaviourTreeView != null && tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
                _behaviourTreeView.PopulateView(tree);
        }

        if (tree != null)
        {
            _treeObject = new SerializedObject(tree);
            _blackboardProperty = _treeObject.FindProperty("_blackboard");
        }
    }

    private void OnNodeSelectionChange(BehaviourNodeView view)
    {
        _inspectorView.UpdateSelection(view);
    }
    
    private void PlayModeStateChanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                OnSelectionChange();
                break;
            
            case PlayModeStateChange.ExitingEditMode:
                break;
            
            case PlayModeStateChange.EnteredPlayMode:
                OnSelectionChange();
                break;
            
            case PlayModeStateChange.ExitingPlayMode:
                break;
        }
    }
}
#endif