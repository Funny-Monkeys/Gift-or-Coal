using System.Collections.Generic;
using System.Linq;
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
            var deeds = new List<Deed>();

            if (Random.Range(1, 4) <= 3)
            {
                for (var i = 0; i < deedsCount; i++)
                {
                    deeds.Add(CreateDeedFromElementIn(Random.Range(1, 4) == 1 ? _badDeeds : _goodDeeds));
                }
            }
            else
            {
                for (var i = 0; i < deedsCount; i++)
                {
                    deeds.Add(CreateDeedFromElementIn(_goodDeeds));
                }
            }

            return deeds;
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