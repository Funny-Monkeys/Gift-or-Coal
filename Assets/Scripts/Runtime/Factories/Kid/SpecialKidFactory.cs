using System.Collections.Generic;
using GiftOrCoal.Deeds;
using GiftOrCoal.KidData;
using GiftOrCoal.Tools.Localization;
using UnityEngine;
using UnityEngine.Localization;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories.Kid
{
    public class SpecialKidFactory : MonoBehaviour, IKidsFactory<IKid>
    {
        [SerializeField] private SpecialKidData _kidData;
        [SerializeField] private List<DeedData> _deedsData;
        [SerializeField] private List<LocalizedString> _localizedStrings;

        private List<DeedData> _badDeeds;
        private List<DeedData> _goodDeeds;

        private void Awake()
        {
            _badDeeds = _deedsData.FindAll(deed => !deed.IsGood);
            _goodDeeds = _deedsData.FindAll(deed => deed.IsGood);
        }

        public IKid Create(KidType kidType)
        {
            var textLocalization = new TextLocalization(_localizedStrings);
            var localizedData = new KidData.KidData(textLocalization.Localize(_kidData.Data.Name), textLocalization.Localize(_kidData.Data.Dossier),
                _kidData.Data.Photo, _kidData.Data.Gender);
            return new KidData.Kid(localizedData, CreateDeeds());
        }

        private IEnumerable<Deed> CreateDeeds()
        {
            return Random.Range(0, 2) == 0 ? CreateDeedsFrom(_goodDeeds, true) : CreateDeedsFrom(_badDeeds, false);
        }

        private List<Deed> CreateDeedsFrom(List<DeedData> deedsData, bool isGood)
        {
            var deeds = new List<Deed>();

            foreach (var data in deedsData)
            {
                var text = new TextLocalization(_localizedStrings).Localize(data.Text);
                deeds.Add(new Deed(text, isGood));
            }

            return deeds;
        }
    }
}