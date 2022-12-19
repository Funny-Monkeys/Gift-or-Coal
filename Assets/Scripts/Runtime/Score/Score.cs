using System;
using UnityEngine;

namespace GiftOrCoal.Score
{
    public sealed class Score : MonoBehaviour
    {
        [SerializeField] private CountView _countView;
        private int _count;

        public event Action<int> OnChanged;

        public void Add(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            _count += count;
            _countView.Visualize(_count);
            OnChanged?.Invoke(_count);
        }

        public bool CanRemove(int count)
        {
            return _count - count >= 0;
        }
        
        public void Remove(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (CanRemove(count) == false)
                throw new InvalidOperationException("Can't remove this count!");
            
            _count -= count;
            _countView.Visualize(_count);
            OnChanged?.Invoke(_count);
        }
    }
}