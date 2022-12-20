using System.Collections.Generic;
using GiftOrCoal.Deeds;
using GiftOrCoal.Dossier;
using UnityEngine;

namespace GiftOrCoal.Factories.Kid
{
    public class RandomKidsFactory : MonoBehaviour
    {
        [SerializeField] private RandomDossierFactory _dossierFactory;
        [SerializeField] private List<DeedData> _deedsData;

        [Space]
        [SerializeField] private List<string> _names;
        [SerializeField] private List<Sprite> _sprites;
        
        private readonly List<DeedData> _usedDeeds = new();
        
        public KidData.Kid Create()
        {
            _usedDeeds.Clear();
            var kidName = _names[Random.Range(0, _names.Count)];
            var generatedDeeds = GenerateDeeds();

            var dossierCreationData = new DossierCreationData(generatedDeeds, kidName);
            var kidData = new KidData.KidData(kidName, _dossierFactory.Create(dossierCreationData), _sprites[Random.Range(0, _sprites.Count)]);
            
            var result = new KidData.Kid(kidData, generatedDeeds);
            return result;
        }

        private List<Deed> GenerateDeeds()
        {
            var result = new List<Deed>();
            var deedsCount = Random.Range(1, 6);

            for (var i = 0; i < deedsCount; i++)
                result.Add(BuildDeed());

            return result;
        }
        
        private Deed BuildDeed()
        {
            var generatedDeed = _deedsData[Random.Range(0, _deedsData.Count)];
            
            while (_usedDeeds.Contains(generatedDeed))
                generatedDeed = _deedsData[Random.Range(0, _deedsData.Count)];
            
            _usedDeeds.Add(generatedDeed);
            return new Deed(generatedDeed.Text, generatedDeed.IsGood);
        }
    }
}