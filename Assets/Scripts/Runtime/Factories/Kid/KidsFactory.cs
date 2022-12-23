using System;
using System.Collections.Generic;
using System.Linq;
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
            var kidTypes = Enum.GetValues(typeof(KidType)).Cast<KidType>().ToList();

            foreach (var type in kidTypes)
            {
                if (!_specialKidsDictionaryComponent.ContainsKey(type))
                    throw new ArgumentOutOfRangeException("", "This type doesn't exist");
            }

            for (var i = 0; i < _specialKidsDictionaryComponent.Keys.Count; i++)
            {
                var key = _specialKidsDictionaryComponent.Keys[i];
                _specialKidsDictionary.Add(key, _specialKidsDictionaryComponent.Values[i]);
            }
        }
    }
}