using Plugins.LaNovel.Editor.Utilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.LaNovel.Editor
{
    public class DSEditorWindow : EditorWindow
    {
        [SerializeField] private StyleSheet variablesStyleSheet;
        [SerializeField] private StyleSheet graphViewStyleSheet;
        [SerializeField] private StyleSheet nodeStyleSheet;
        
        [MenuItem("Dialogue System/Dialogue Graph")]
        private static void ShowWindow()
        {
            DSEditorWindow window = GetWindow<DSEditorWindow>();
            window.titleContent = new GUIContent("Dialogue Graph");
            window.Show();
        }
        
        private void CreateGUI()
        {
            AddGraphView();
            AddStyles();
        }
        
        private void AddStyles()
        {
            rootVisualElement.AddStyleSheet(variablesStyleSheet);
        }
        
        private void AddGraphView()
        {
            DSGraphView dsGraphView = new DSGraphView(this, graphViewStyleSheet, nodeStyleSheet);
            dsGraphView.StretchToParentSize();
            rootVisualElement.Add(dsGraphView);
        }
    }
}