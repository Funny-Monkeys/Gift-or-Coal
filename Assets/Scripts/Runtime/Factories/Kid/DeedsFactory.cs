using System.Collections.Generic;
using GiftOrCoal.Deeds;
using GiftOrCoal.Difficult;
using GiftOrCoal.Save;
using UnityEngine;

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
            var difficultDataStorage = new StorageWithNameSaveObject<DifficultData, DifficultData>();
            var difficultData = difficultDataStorage.Load();
            var deedsCount = Random.Range(difficultData.MinDeedsCount, difficultData.MaxDeedsCount);

            if (Random.Range(1, 4) <= 1)
            {
                for (var i = 0; i < deedsCount; i++)
                {
                    yield return CreateDeedFromElementIn(Random.Range(1, 4) == 1 ? _badDeeds : _goodDeeds);
                }
            }
            
            else
            {
                for (var i = 0; i < deedsCount; i++)
                {
                    yield return CreateDeedFromElementIn(_goodDeeds);
                }
            }
        }

        private Deed CreateDeedFromElementIn(List<DeedData> deedDataList)
        {
            var randomIndex = Random.Range(0, deedDataList.Count);
            var generatedDeed = deedDataList[randomIndex];
            deedDataList.Remove(generatedDeed);
            return new Deed(generatedDeed.Text, generatedDeed.IsGood);
        }
    }
}