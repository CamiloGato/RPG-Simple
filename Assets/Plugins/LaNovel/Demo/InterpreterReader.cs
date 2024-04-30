using TMPro;
using UnityEngine;

namespace Plugins.LaNovel.Demo
{
    public class InterpreterReader : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Start()
        {
            text.text = "Text";
        }
    }
}