using System;
using GiftOrCoal.Factories.Kid;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.House
{
    public sealed class House : MonoBehaviour
    {
        [field: SerializeField] public HouseMovement Movement { get; private set; }
        
        [field: SerializeField] public KidType KidType { get; private set; }

        public RandomKidsFactory RandomKidsFactory { get; private set; }
        
        public void Init(RandomKidsFactory randomKidsFactory)
        {
            RandomKidsFactory = randomKidsFactory ?? throw new ArgumentNullException(nameof(randomKidsFactory));
        }
    }
}