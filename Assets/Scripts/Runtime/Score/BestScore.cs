using GiftOrCoal.Other;
using GiftOrCoal.Save;
using UnityEngine;

namespace GiftOrCoal.Score
{
    public sealed class BestScore : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private CountViews _countView;
        
        private readonly StorageWithNames<BestScore, int> _storage = new();
        private int _count;
        
        private void OnEnable()
        {
            _score.OnChanged += OnChanged;
            _count = _storage.HasSave() ? _storage.Load() : 0;
            _countView.Visualize(_count);
        }

        private void OnDisable()
        {
            _score.OnChanged -= OnChanged;
        }

        private void OnChanged(int scoreCount)
        {
            if (_count < scoreCount)
            {
                _count = scoreCount;
                _countView.Visualize(_count);
                _storage.Save(_count);
            }
        }
    }
}