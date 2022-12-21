using System.Collections.Generic;
using GiftOrCoal.Factories.Kid;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.House
{
    public sealed class House : MonoBehaviour
    {
        [SerializeField] private KidsFactory _kidsFactory;
        [SerializeField] private KidType _kidType;
        
        [Space]
        [SerializeField] private List<GameObject> _attributes;
        
        [field: SerializeField] public HouseMovement Movement { get; private set; }

        public IKid CreateKid()
        {
            return _kidsFactory.Create(_kidType);
        }

        public void TurnOnAttributes()
        {
            _attributes.ForEach(attribute => attribute.SetActive(false));
            foreach (var attribute in _attributes)
                attribute.SetActive(Random.Range(1, 3) == 1);
        }
    }
}