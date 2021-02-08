using System;
using TMPro;
using UnityEngine;

namespace PatternsChudakovGA
{
    public sealed class TextPanel : BaseUI
    {
        private readonly GameObject _gameObject;
        private TextMeshProUGUI _text;

        public TextPanel(GameObject gameObject)
        {
            _gameObject = gameObject;
            _text = _gameObject.GetComponent<TextMeshProUGUI>();
        }

        public override void Execute()
        {
            _gameObject.SetActive(true);
        }

        public void AddInfo(string text, bool addOrinject)
        {
            if (addOrinject)
                _text.text += "\n" + text;
            else
            {
                _text.text = text;
            }
        }

        
        
        public override void Cancel()
        {
            _gameObject.SetActive(false);
        }
    }
}