using GiftOrCoal.Factories.Kid;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.House
{
    public sealed class House : MonoBehaviour
    {
        [SerializeField] private KidsFactory _kidsFactory;
        [SerializeField] private KidType _kidType;
        
        [field: SerializeField] public HouseMovement Movement { get; private set; }

        public IKid CreateKid()
        {
            return _kidsFactory.Create(_kidType);
        }
    }
}