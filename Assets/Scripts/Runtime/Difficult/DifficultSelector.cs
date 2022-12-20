using System;
using GiftOrCoal.SaveSystem;
using UnityEngine;

namespace GiftOrCoal.Difficult
{
    public sealed class DifficultSelector : MonoBehaviour
    {
        private DifficultData _defaultDifficultData;
        private DifficultData[] _difficultData;
        private readonly StorageWithNameSaveObject<DifficultData, DifficultData> _storage = new();

        public void Init(DifficultData defaultDifficultData, DifficultData[] difficultData)
        {
            _difficultData = difficultData ?? throw new ArgumentNullException(nameof(difficultData));
            _defaultDifficultData = defaultDifficultData;
            
            if (_storage.HasSave() == false)
            {
                _storage.Save(_defaultDifficultData);
            }
        }

        public void Select(int index)
        {
            if (_difficultData.Length < index)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            if (index < 0) 
                throw new ArgumentOutOfRangeException(nameof(index));

            var difficult = _difficultData[index];
            _storage.Save(difficult);
        }
    }
}