﻿using GiftOrCoal.Save;
using GiftOrCoal.View;
using UnityEngine;

namespace GiftOrCoal.Score
{
    public sealed class BestScore : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private CountView _countView;
        
        private readonly StorageWithNameSaveObject<BestScore, int> _storage = new();
        private int _count;
        
        private void OnEnable()
        {
            _count = _storage.HasSave() ? _storage.Load() : 0;
            _countView.Visualize(_count);
        }

        private void Update()
        {
            if (_score.HasChanged)
            {
                var scoreCount = _score.Count;
                
                if (_count < scoreCount)
                {
                    _count = scoreCount;
                    _countView.Visualize(_count);
                    _storage.Save(_count);
                }
            }
        }
    }
}