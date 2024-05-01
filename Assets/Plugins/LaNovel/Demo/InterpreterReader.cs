using System.IO;
using Plugins.LaNovel.Runtime.Interpreter;
using TMPro;
using UnityEngine;

namespace Plugins.LaNovel.Demo
{
    public class InterpreterReader : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_InputField inputField;

        private readonly string _path = $"{Application.dataPath}/Data/Demo.lnov";
        
        private void Start()
        {
            text.text = "Text";
        }
        
        public void Save()
        {
            string contents = inputField.text;
            File.WriteAllText(_path, contents);
#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }

        public void Load()
        {
            string result = LaNov.Instance.Interpreter.ExecuteFile(_path);
            text.text = result;
        }
    }
}