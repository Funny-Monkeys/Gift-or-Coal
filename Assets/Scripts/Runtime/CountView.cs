using System.Globalization;
using TMPro;
using UnityEngine;

public sealed class CountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _additionSymbols;

    public void Visualize(float count)
    {
        var countText = count.ToString(CultureInfo.InvariantCulture);
        _text.text = _additionSymbols.Length == 0 ? countText : countText + _additionSymbols;
    }
}