using System.Collections.Generic;
using GiftOrCoal.Background;
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
        [SerializeField] private List<Sprite> _timesOfDaySprites;

        [field: SerializeField, Space] public HouseMovement Movement { get; private set; }
        [SerializeField] private SpriteRenderer _houseSpriteRenderer;

        public IKid Kid { get; private set; }
        
        private KidType _kidType;

        public IKid CreateKid()
        {
            var kid = _kidsFactory.Create(_houseType == HouseType.Standard ? KidType.Standard : _kidType);
            Kid = kid;
            return kid;
        }

        public void InitTimeOfDay(TimeOfDay time) => _houseSpriteRenderer.sprite = _timesOfDaySprites[(int)time];

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