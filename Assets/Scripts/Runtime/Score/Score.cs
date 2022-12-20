using System;
using GiftOrCoal.View;
using UnityEngine;

namespace GiftOrCoal.Score
{
    public sealed class Score : MonoBehaviour
    {
        [SerializeField] private CountView _countView;
        public int Count { get; private set; }

        public bool HasChanged { get; private set; }

        public void Add(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            Count += count;
            _countView.Visualize(Count);
            HasChanged = true;
        }

        private void LateUpdate() => HasChanged = false;

        public bool CanRemove(int count)
        {
            return Count - count >= 0;
        }
        
        public void Remove(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (CanRemove(count) == false)
                throw new InvalidOperationException("Can't remove this count!");
            
            Count -= count;
            _countView.Visualize(Count);
            HasChanged = true;
        }
    }
}