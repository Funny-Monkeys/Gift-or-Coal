using System.Collections.Generic;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.Factories.Kid
{
    public class RandomKidsFactory : MonoBehaviour
    {
        [SerializeField] private RandomDossierFactory _dossierFactory;
        [SerializeField] private DeedsFactory _deedsFactory;
        
        [Space]
        [SerializeField] private List<string> _names;
        [SerializeField] private List<Sprite> _sprites;

        public IKid Create()
        {
            var kidName = _names[Random.Range(0, _names.Count)];
            var generatedDeeds = _deedsFactory.CreateDeeds();
            var dossierText = _dossierFactory.Create(kidName);
            
            var kidData = new KidData.KidData(kidName, dossierText, _sprites[Random.Range(0, _sprites.Count)]);
            var kid = new KidData.Kid(kidData, generatedDeeds);
            return kid;
        }
    }
}