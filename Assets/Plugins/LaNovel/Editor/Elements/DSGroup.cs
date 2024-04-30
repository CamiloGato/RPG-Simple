using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Plugins.LaNovel.Editor.Elements
{
    public class DSGroup : Group
    {

        public void Initialize(string newTitle, Vector2 position)
        {
            title = newTitle;
            
            SetPosition(new Rect(position, Vector2.zero));
        }
    }
}