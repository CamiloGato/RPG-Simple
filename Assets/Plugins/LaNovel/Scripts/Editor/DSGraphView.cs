using System;
using System.Collections.Generic;
using DialogueSystem.Runtime.Enumerations;
using Plugins.LaNovel.Scripts.Editor.Elements;
using Plugins.LaNovel.Scripts.Editor.Utilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.LaNovel.Scripts.Editor
{
    public class DSGraphView : GraphView
    {
        private readonly DSEditorWindow _dsEditorWindow;
        private readonly StyleSheet _graphViewStyleSheet;
        private readonly StyleSheet _nodeStyleSheet;
        private DSSearchWindow _searchWindow;
        
        public DSGraphView(DSEditorWindow dsEditorWindow, StyleSheet graphViewStyleSheet, StyleSheet nodeStyleSheet)
        {
            _dsEditorWindow = dsEditorWindow;
            _graphViewStyleSheet = graphViewStyleSheet;
            _nodeStyleSheet = nodeStyleSheet;

            AddManipulators();
            AddGridBackground();
            AddSearchWindow();
            
            AddStyles();
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePort = new List<Port>();

            ports.ForEach(port =>
            {
                if (startPort == port)
                    return;
                if (startPort.node == port.node)
                    return;
                if (startPort.direction == port.direction)
                    return;
                
                compatiblePort.Add(port);
            });
            
            return compatiblePort;
        }

        private void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            
            this.AddManipulator(CreateNodeContextMenu("Add Node (Single Choice)",DSDialogueType.SingleChoice));
            this.AddManipulator(CreateNodeContextMenu("Add Node (Multiple Choice)",DSDialogueType.MultipleChoice));
            
            this.AddManipulator(CreateGroupContextMenu());
        }

        private IManipulator CreateNodeContextMenu(string actionTitle, DSDialogueType dialogueType)
        {
            ContextualMenuManipulator menuManipulator = new ContextualMenuManipulator(
                menuEvent =>
                    menuEvent.menu.AppendAction(
                        actionTitle,
                        actionEvent =>
                            AddElement(
                                CreateNode(
                                    dialogueType,
                                    GetLocalMousePosition(actionEvent.eventInfo.localMousePosition)
                                    )
                            )
                    )
            );
            
            return menuManipulator;
        }

        private IManipulator CreateGroupContextMenu()
        {
            ContextualMenuManipulator menuManipulator = new ContextualMenuManipulator(
                menuEvent =>
                    menuEvent.menu.AppendAction(
                        "Add Group",
                        actionEvent =>
                            AddElement(
                                CreateGroup(
                                    "DialogueGroup",
                                    GetLocalMousePosition(actionEvent.eventInfo.localMousePosition)
                                    )
                            )
                    )
            );

            return menuManipulator;
        }

        public DSGroup CreateGroup(string title, Vector2 position)
        {
            DSGroup group = new DSGroup();
            
            group.Initialize(title, position);
            
            return group;
        }

        public DSNode CreateNode(DSDialogueType dialogueType, Vector2 position)
        {
            Type nodeType = Type.GetType($"DialogueSystem.Editor.Elements.DS{dialogueType}Node");
            
            if (nodeType == null)
                throw new Exception($"Error in {dialogueType} no found.");
            if (Activator.CreateInstance(nodeType) is not DSNode node)
                throw new Exception($"No instance for {nodeType.Name} as {typeof(DSNode)}");
            
            node.Initialize(position);
            node.Draw();
            
            return node;
        }
        
        private void AddGridBackground()
        {
            GridBackground gridBackground = new GridBackground();
            gridBackground.StretchToParentSize();
            Insert(0, gridBackground);
        }
        
        private void AddSearchWindow()
        {
            _searchWindow ??= ScriptableObject.CreateInstance<DSSearchWindow>().Initialize(this);
            nodeCreationRequest = context =>
            {
                SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), _searchWindow);
            };
        }
        
        private void AddStyles()
        {
            this.AddStyleSheet(
                _graphViewStyleSheet,
                _nodeStyleSheet
            );
        }

        public Vector2 GetLocalMousePosition(Vector2 mousePosition, bool isSearchWindow = false)
        {
            Vector2 worldMousePosition = 
                mousePosition - (isSearchWindow ? _dsEditorWindow.position.position : Vector2.zero);
            
            Vector2 localMousePosition = contentViewContainer.WorldToLocal(worldMousePosition);
            
            return localMousePosition;
        }
    }
}