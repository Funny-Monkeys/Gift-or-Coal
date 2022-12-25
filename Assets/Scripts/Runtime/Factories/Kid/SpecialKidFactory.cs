using System.Collections.Generic;
using GiftOrCoal.Deeds;
using GiftOrCoal.KidData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories.Kid
{
    public class SpecialKidFactory : MonoBehaviour, IKidsFactory<IKid>
    {
        [SerializeField] private SpecialKidData _kidData;
        [SerializeField] private List<DeedData> _deedsData;
        private List<DeedData> _badDeeds;
        private List<DeedData> _goodDeeds;
        
        private void Awake()
        {
            _badDeeds = _deedsData.FindAll(deed => !deed.IsGood);
            _goodDeeds = _deedsData.FindAll(deed => deed.IsGood);
        }

        public IKid Create(KidType kidType)
        {
            return new KidData.Kid(_kidData.Data, CreateDeeds());
        }

        private IEnumerable<Deed> CreateDeeds()
        {
            var deeds = new List<Deed>();
            
            if (Random.Range(0, 2) == 0)
            {
                foreach (var goodDeed in _goodDeeds)
                {
                    deeds.Add(new Deed(goodDeed.Text, true));
                }
            }

            else
            {
                foreach (var badDeed in _badDeeds)
                {
                    deeds.Add(new Deed(badDeed.Text, false));
                }
            }

            return deeds;
        }
    }
}