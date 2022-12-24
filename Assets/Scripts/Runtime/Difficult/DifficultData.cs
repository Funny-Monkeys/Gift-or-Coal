using System;
using UnityEngine;

namespace GiftOrCoal.Difficult
{
    [Serializable]
    public struct DifficultData
    {
        [field: SerializeField] public string Name { get; private set; }

        [field: SerializeField, Min(1)] public int MinDeedsCount { get; private set; }

        [field: SerializeField, Min(1)] public int MaxDeedsCount { get; private set; }

        [field: SerializeField, Min(1)] public int ScoreAddCount { get; private set; }
        
        [field: SerializeField, Min(1)] public int ScoreRemoveCount { get; private set; }

        
        private void OnValidate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Debug.LogWarning("Name is null!");
            }

            if (MaxDeedsCount < MinDeedsCount)
            {
                Debug.LogWarning("Max deed is smaller than min!!");
            }
        }
    }
}