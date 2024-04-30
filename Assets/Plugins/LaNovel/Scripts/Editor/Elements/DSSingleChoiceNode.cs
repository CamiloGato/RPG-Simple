﻿using DialogueSystem.Runtime.Enumerations;
using Plugins.LaNovel.Scripts.Editor.Utilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Plugins.LaNovel.Scripts.Editor.Elements
{
    public class DSSingleChoiceNode : DSNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);
            DialogueType = DSDialogueType.SingleChoice;
            Choices.Add("Next Dialog");
        }

        public override void Draw()
        {
            base.Draw();

            // Output Container
            
            foreach (string choice in Choices)
            {
                Port choicePort = this.CreatePort(choice);
                
                outputContainer.Add(choicePort);
            }
            
            RefreshExpandedState();
        }
    }
}