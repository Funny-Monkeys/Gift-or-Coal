using System;
using System.Collections.Generic;
using GiftOrCoal.Deeds;
using GiftOrCoal.Difficult;
using GiftOrCoal.Save;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories.Kid
{
    public sealed class DeedsFactory : MonoBehaviour
    {
        [SerializeField] private List<DeedData> _deedsData;
        private List<DeedData> _badDeeds;
        private List<DeedData> _goodDeeds;

        private void OnEnable()
        {
            _badDeeds = _deedsData.FindAll(deed => !deed.IsGood);
            _goodDeeds = _deedsData.FindAll(deed => deed.IsGood);
        }

        public IEnumerable<Deed> CreateDeeds()
        {
            var difficultDataStorage = new StorageWithNames<DifficultData, DifficultData>();
            var difficultData = difficultDataStorage.Load();

            var deedsCount = Random.Range(difficultData.MinDeedsCount, difficultData.MaxDeedsCount);
            var deeds = new List<Deed>();

            for (var i = 0; i < deedsCount; i++)
            {
                try { deeds.Add(CreateDeedFromElementIn(Random.Range(0, 6) <= 2 ? _badDeeds : _goodDeeds)); }
                catch (InvalidOperationException) { }
            }

            return deeds;
        }

        private Deed CreateDeedFromElementIn(List<DeedData> deedDataList)
        {
            if (deedDataList.Count == 0)
                throw new InvalidOperationException("Not enough deeds in list");
            
            var randomIndex = Random.Range(0, deedDataList.Count);
            var generatedDeed = deedDataList[randomIndex];
            deedDataList.Remove(generatedDeed);
            return new Deed(generatedDeed.Text, generatedDeed.IsGood);
        }
    }
}