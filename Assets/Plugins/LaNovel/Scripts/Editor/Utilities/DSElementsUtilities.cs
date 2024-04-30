using System;
using Plugins.LaNovel.Scripts.Editor.Elements;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Plugins.LaNovel.Scripts.Editor.Utilities
{
    public static class DSElementsUtilities
    {
        public static Foldout CreateFoldout(string title, bool collapsed = false)
        {
            Foldout foldout = new Foldout()
            {
                text = title,
                value = !collapsed,
            };
            
            return foldout;
        }

        public static TextField CreateTextField(
            string value = null,
            EventCallback<ChangeEvent<string>> onValueChange = null
        )
        {
            TextField textField = new TextField()
            {
                value = value
            };

            if (onValueChange != null)
            {
                textField.RegisterValueChangedCallback(onValueChange);
            }

            return textField;
        }

        public static TextField CreateTextArea(
            string value = null,
            EventCallback<ChangeEvent<string>> onValueChange = null
        )
        {
            TextField textArea = new TextField()
            {
                value = value,
                multiline = true,
            };

            if (onValueChange != null)
            {
                textArea.RegisterValueChangedCallback(onValueChange);
            }

            return textArea;
        }

        public static Button CreateButton(string value = null, Action onClick = null)
        {
            Button button = new Button(onClick)
            {
                text = value
            };
            
            return button;
        }

        public static Port CreatePort(
            this DSNode node,
            string portName = "",
            Orientation orientation = Orientation.Horizontal,
            Direction direction = Direction.Output,
            Port.Capacity capacity = Port.Capacity.Single
            )
        {
            Port port = node.InstantiatePort(orientation, direction, capacity, typeof(bool));
            port.portName = portName;
            return port;
        }
    }
}