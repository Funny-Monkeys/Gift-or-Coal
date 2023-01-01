using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GiftOrCoal.Other
{
    public sealed class CountViews : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _texts;
        [SerializeField] private string _additionSymbols;
        [SerializeField] private bool _needTrim;
        
        public void Visualize(float count)
        {
            var countText = count.ToString();

            if (countText.Length > 2 && _needTrim)
                countText = countText.Substring(0, 2);
            
            _texts.ForEach(text => text.text = _additionSymbols.Length == 0 ? countText : countText + _additionSymbols);
        }
    }
}