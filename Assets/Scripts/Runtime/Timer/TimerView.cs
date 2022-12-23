using TMPro;
using UnityEngine;

namespace GiftOrCoal.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        public void Display(int timeInSeconds) => _timerText.text = $"{timeInSeconds / 60}:{(timeInSeconds % 60).ToString().PadLeft(2, '0')}";
    }
}