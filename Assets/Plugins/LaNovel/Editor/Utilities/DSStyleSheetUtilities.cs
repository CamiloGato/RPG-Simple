using UnityEditor;
using UnityEngine.UIElements;

namespace Plugins.LaNovel.Editor.Utilities
{
    public static class DSStyleSheetUtilities
    {
        public static VisualElement AddStyleSheet(this VisualElement element, params string[] styles)
        {
            foreach (string style in styles)
            {
                StyleSheet styleSheet = (StyleSheet)EditorGUIUtility.Load(style);
                element.styleSheets.Add(styleSheet);
            }

            return element;
        }

        public static VisualElement AddStyleSheet(this VisualElement element, params StyleSheet[] style)
        {
            foreach (StyleSheet styleSheet in style)
            {
                element.styleSheets.Add(styleSheet);
            }

            return element;
        }

        public static T AddClasses<T>(this T element, params string[] classes) where T : VisualElement
        {
            foreach (string @class in classes)
            {
                element.AddToClassList(@class);
            }

            return element;
        }
    }
}