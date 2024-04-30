using System.Collections.Generic;
using DialogueSystem.Runtime.Enumerations;
using Plugins.LaNovel.Scripts.Editor.Elements;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Plugins.LaNovel.Scripts.Editor
{
    public class DSSearchWindow : ScriptableObject, ISearchWindowProvider
    {
        private DSGraphView _graphView;
        private Texture2D _indentationIcon;
        
        private Vector2 GetMousePosition(SearchWindowContext context) => 
            _graphView.GetLocalMousePosition(context.screenMousePosition, true);
        
        public DSSearchWindow Initialize(DSGraphView graphView)
        {
            _graphView = graphView;

            _indentationIcon = new Texture2D(1, 1);
            _indentationIcon.SetPixel(0,0, Color.clear);
            _indentationIcon.Apply();
            
            return this;
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> searchTreeEntries = new List<SearchTreeEntry>()
            {
                new SearchTreeGroupEntry(new GUIContent("Create Element")),
                new SearchTreeGroupEntry(new GUIContent("Dialogue Node"), 1),
                new SearchTreeEntry(new GUIContent("Single Choice", _indentationIcon))
                {
                    level = 2,
                    userData = _graphView.CreateNode(
                        DSDialogueType.SingleChoice,
                        GetMousePosition(context)
                    ),
                },
                new SearchTreeEntry(new GUIContent("Multiple Choice", _indentationIcon))
                {
                    level = 2,
                    userData = _graphView.CreateNode(
                        DSDialogueType.MultipleChoice,
                        GetMousePosition(context)
                    ),
                },
                new SearchTreeGroupEntry(new GUIContent("Dialogue Group"), 1),
                new SearchTreeEntry(new GUIContent("Single Group", _indentationIcon))
                {
                    level = 2,
                    userData = _graphView.CreateGroup(
                        "Dialogue Group",
                        GetMousePosition(context)
                    ),
                }
            };
            
            return searchTreeEntries;
        }

        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            switch (searchTreeEntry.userData)
            {
                case DSNode node:
                    _graphView.AddElement(node);
                    return true;
                
                case DSGroup group:
                    _graphView.AddElement(group);
                    return true;
                
                default:
                    return false;
                
            }
        }
    }
}