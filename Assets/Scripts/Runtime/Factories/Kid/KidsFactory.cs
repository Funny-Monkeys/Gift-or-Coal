using System;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.Factories.Kid
{
    public class KidsFactory : MonoBehaviour, IKidsFactory<KidData.Kid>
    {
        [SerializeField] private RandomKidsFactory _randomKidsFactory;
        
        public KidData.Kid Create(KidType kidType)
        {
            return kidType switch
            {
                KidType.Standard => _randomKidsFactory.Create(),
                _ => throw new Exception("Invalid KidType")
            };
        }
    }
}