﻿using UnityEngine;
using UnityEngine.UI;

namespace GiftOrCoal.LoadSystem
{
    public sealed class LoadingBar : MonoBehaviour
    {
        [SerializeField] private Scrollbar _slider;
        private static Scrollbar _bar;

        private void Start()
        {
            _bar = _slider;
        }

        public static void Visualize(float value)
        {
            _bar.size = value;
        }
    }
}