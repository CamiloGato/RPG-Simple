using System.Collections.Generic;
using DialogueSystem.Runtime.Enumerations;
using Plugins.LaNovel.Scripts.Editor.Utilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.LaNovel.Scripts.Editor.Elements
{
    public class DSNode : Node
    {
        public string DialogueName { get; set; }
        public List<string> Choices { get; set; }
        public string Text { get; set; }
        public DSDialogueType DialogueType { get; set; }

        public virtual void Initialize(Vector2 position)
        {
            DialogueName = "DialogueName";
            Choices = new List<string>();
            Text = "Dialogue Text";
            
            SetPosition(new Rect(position, Vector2.zero));
            
            mainContainer.AddClasses("ds-node__main-container");
            extensionContainer.AddClasses("ds-node__extension-container");
        }

        public virtual void Draw()
        {
            // Title Container

            TextField dialogueNameTextField = 
                DSElementsUtilities.CreateTextField(DialogueName)
                    .AddClasses(
                        "ds-node__textfield",
                        "ds-node__textfield__hidden",
                        "ds-node__filename-textfield"
                        );
            
            titleContainer.Insert(0, dialogueNameTextField);

            // Input Container

            Port inputPort = this.CreatePort(
                "Dialogue Connection",
                direction: Direction.Input,
                capacity: Port.Capacity.Multi
            );
            
            inputContainer.Add(inputPort);

            // Extension Container
            
            VisualElement customDataContainer = new VisualElement()
                .AddClasses(
                    "ds-node__custom-data-container"
                    );

            Foldout textFoldout = DSElementsUtilities.CreateFoldout("Dialogue Text");
            
            TextField textTextField = DSElementsUtilities.CreateTextArea(Text)
                .AddClasses(
                    "ds-node__textfield",
                    "ds-node__quote-textfield"
                    );
            
            textFoldout.Add(textTextField);
            customDataContainer.Add(textFoldout);
            
            extensionContainer.Add(customDataContainer);
        }
    }
}