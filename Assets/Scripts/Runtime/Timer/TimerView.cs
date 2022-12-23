﻿using TMPro;
using UnityEngine;

namespace GiftOrCoal.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private string _prefix;
        [SerializeField] private TextMeshProUGUI _timerText;

        public void Display(float timeInSeconds)
        {
            _timerText.text = $"{_prefix}{(int)timeInSeconds / 60}:{((int)timeInSeconds % 60).ToString().PadLeft(2, '0')}";
        }
    }
}