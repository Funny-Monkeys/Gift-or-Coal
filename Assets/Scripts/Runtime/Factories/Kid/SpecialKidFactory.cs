using System.Collections.Generic;
using GiftOrCoal.Deeds;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.Factories.Kid
{
    public class SpecialKidFactory : MonoBehaviour, IKidsFactory<IKid>
    {
        [SerializeField] private SpecialKidData _kidData;

        public IKid Create(KidType kidType)
        {
            var deeds = new List<Deed> { new("", _kidData.IsGood) };
            return new KidData.Kid(_kidData.Data, deeds);
        }
    }
}