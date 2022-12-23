using TMPro;
using UnityEngine;

namespace GiftOrCoal.Other
{
    public sealed class CountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _additionSymbols;

        public void Visualize(float count)
        {
            var countText = count.ToString();
            _text.text = _additionSymbols.Length == 0 ? countText : countText + _additionSymbols;
        }
    }
}