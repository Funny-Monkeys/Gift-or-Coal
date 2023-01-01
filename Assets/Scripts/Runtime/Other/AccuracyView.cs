using TMPro;
using UnityEngine;

namespace GiftOrCoal.Other
{
    public sealed class AccuracyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public void Visualize(float count)
        {
            var countText = count.ToString();
            
            if (countText.Length > 2 && countText.Contains("."))
                countText = countText.Substring(0, 2);

            _text.text = countText + "%";
        }
    }
}