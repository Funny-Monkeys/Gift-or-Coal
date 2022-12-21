﻿using System.Collections.Generic;
using GiftOrCoal.Factories.Kid;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.House
{
    public sealed class House : MonoBehaviour
    {
        [SerializeField] private KidsFactory _kidsFactory;
        [SerializeField] private HouseType _houseType;
        
        [Space]
        [SerializeField] private List<GameObject> _attributes;
        
        [field: SerializeField] public HouseMovement Movement { get; private set; }

        private KidType _kidType;

        public IKid CreateKid()
        {
            Debug.Log(_kidType);
            Debug.Log(_houseType);
            return _kidsFactory.Create(_houseType == HouseType.Standard ? KidType.Standard : _kidType);
        }

        public void TurnOnAttributes()
        {
            _attributes.ForEach(attribute => attribute.SetActive(false));
            foreach (var attribute in _attributes)
                attribute.SetActive(Random.Range(1, 3) == 1);
        }

        public void Init(KidType randomKidType)
        {
            _kidType = randomKidType;
        }
    }
}