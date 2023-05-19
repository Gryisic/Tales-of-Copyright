#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UIElements;

public class InspectorView : VisualElement
{
    public new class UxmlFactory: UxmlFactory<InspectorView, UxmlTraits> { }

    private Editor _editor;
    
    public InspectorView() { }

    public void UpdateSelection(BehaviourNodeView view)
    {
        Clear();

        UnityEngine.Object.DestroyImmediate(_editor);
        
        _editor = Editor.CreateEditor(view.Node);
        IMGUIContainer container = new IMGUIContainer(() =>
        {
            if (_editor.target)
                _editor.OnInspectorGUI();
        });
        
        Add(container);
    }
}
#endif