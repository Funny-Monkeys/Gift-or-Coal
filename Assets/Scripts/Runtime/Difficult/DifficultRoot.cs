using System.Linq;
using GiftOrCoal.Save;
using UnityEngine;

namespace GiftOrCoal.Difficult
{
    public sealed class DifficultRoot : MonoBehaviour
    {
        [SerializeField] private DifficultData _defaultDifficultData;
        [SerializeField] private DifficultData[] _difficultData;
        [SerializeField] private DifficultDropDown _difficultDropDown;
        [SerializeField] private DifficultSelector _difficultSelector;
        
        private void Awake()
        {
            var storage = new StorageWithNames<DifficultData, DifficultData>();
            var dropDownStartValue = 0;
            
            if (storage.HasSave())
            {
                var lastSavedDifficultIndex = _difficultData.ToList().IndexOf(storage.Load());
                dropDownStartValue = lastSavedDifficultIndex;
            }
            
            _difficultDropDown.Init(_difficultData, dropDownStartValue);
            _difficultSelector.Init(_defaultDifficultData, _difficultData);
            _difficultDropDown.Subscribe(_difficultSelector.Select);
        }
    }
}