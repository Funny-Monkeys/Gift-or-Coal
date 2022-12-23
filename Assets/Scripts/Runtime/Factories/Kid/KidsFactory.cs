using System.Collections.Generic;
using GiftOrCoal.KidData;
using GiftOrCoal.Tools;
using UnityEngine;

namespace GiftOrCoal.Factories.Kid
{
    public class KidsFactory : MonoBehaviour, IKidsFactory<IKid>
    {
        [SerializeField] private RandomKidsFactory _randomKidsFactory;
        [SerializeField] private KidsDictionary _specialKidsDictionaryComponent;
        private readonly Dictionary<KidType, SpecialKidFactory> _specialKidsDictionary = new();

        public IKid Create(KidType kidType)
        {
            if (kidType == KidType.Standard)
                return _randomKidsFactory.Create();

            return _specialKidsDictionary[kidType].Create(kidType);
        }

        private void Awake()
        {
            for (var i = 0; i < _specialKidsDictionaryComponent.Keys.Count; i++)
            {
                var key = _specialKidsDictionaryComponent.Keys[i];
                _specialKidsDictionary.Add(key, _specialKidsDictionaryComponent.Values[i]);
            }
        }
    }
}