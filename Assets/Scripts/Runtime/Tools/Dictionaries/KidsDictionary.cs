using System;
using GiftOrCoal.Factories.Kid;
using GiftOrCoal.KidData;

namespace GiftOrCoal.Tools
{
    [Serializable]
    public class KidsDictionary : UnityDictionary<KidType, SpecialKidFactory> { }
}