using System;
using GiftOrCoal.Other;
using UnityEngine;

namespace GiftOrCoal.Score
{
    public sealed class Score : MonoBehaviour
    {
        [SerializeField] private CountViews _countView;
        
        public int Count { get; private set; }

        public event Action<int> OnChanged;

        public void Add(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            Count += count;
            _countView.Visualize(Count);
            OnChanged?.Invoke(Count);
        }

        public bool CanRemove(int count)
        {
            return Count - count >= 0;
        }
        
        public void Remove(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (CanRemove(count) == false)
                throw new InvalidOperationException("Can't remove this count!");
            
            Count -= count;
            _countView.Visualize(Count);
            OnChanged?.Invoke(Count);
        }
    }
}