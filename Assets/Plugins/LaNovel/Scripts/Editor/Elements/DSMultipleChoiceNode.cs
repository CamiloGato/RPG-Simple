using DialogueSystem.Runtime.Enumerations;
using Plugins.LaNovel.Scripts.Editor.Utilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.LaNovel.Scripts.Editor.Elements
{
    public class DSMultipleChoiceNode : DSNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);
            DialogueType = DSDialogueType.MultipleChoice;
            Choices.Add("New Choice");
        }
        
        public override void Draw()
        {
            base.Draw();

            // Main Container

            Button addChoiceButton = DSElementsUtilities.CreateButton("Add Choice", () =>
            {
                Port choicePort = CreateChoicePort("New Choice");
                Choices.Add("New Choice");
                
                outputContainer.Add(choicePort); 
            })
            .AddClasses(
                "ds-node__button"
                );
            
            mainContainer.Insert(1, addChoiceButton);
            
            // Output Container
            
            foreach (string choice in Choices)
            {
                Port choicePort = CreateChoicePort(choice);
                
                outputContainer.Add(choicePort);
            }
            
            RefreshExpandedState();
        }

        private Port CreateChoicePort(string value)
        {
            Port choicePort = this.CreatePort();

            Button deleteChoiceButton = 
                DSElementsUtilities.CreateButton("X")
                .AddClasses(
                    "ds-node__button"
                    );

            TextField textField = DSElementsUtilities.CreateTextField(value)
                .AddClasses(
                    "ds-node__textfield",
                    "ds-node__textfield__hidden",
                    "ds-node__choice-textfield"
                    );
            
            choicePort.Add(deleteChoiceButton);
            choicePort.Add(textField);

            return choicePort;
        }
        
    }
}