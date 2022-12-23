using System.Collections.Generic;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.Factories.Kid
{
    public sealed class RandomKidsFactory : MonoBehaviour
    {
        [SerializeField] private RandomDossierFactory _dossierFactory;
        [SerializeField] private DeedsFactory _deedsFactory;

        [Space] 
        [SerializeField] private List<string> _maleNames;
        [SerializeField] private List<Sprite> _maleSprites;

        [Space] 
        [SerializeField] private List<string> _femaleNames;
        [SerializeField] private List<Sprite> _femaleSprites;

        public IKid Create()
        {
            var gender = Gender.Male;

            if (Random.Range(0, 3) == 2)
                gender = Gender.Female;

            var kidName = gender == Gender.Male ? _maleNames[Random.Range(0, _maleNames.Count)] : _femaleNames[Random.Range(0, _maleNames.Count)];
            var generatedDeeds = _deedsFactory.CreateDeeds();
            var dossierText = _dossierFactory.Create(kidName);
            var femaleSprite = _femaleSprites[Random.Range(0, _maleSprites.Count)];
            var maleSprite = _maleSprites[Random.Range(0, _maleSprites.Count)];
            var kidData = new KidData.KidData(kidName, dossierText, gender == Gender.Male ? maleSprite : femaleSprite, gender);
            var kid = new KidData.Kid(kidData, generatedDeeds);
            return kid;
        }
    }
}