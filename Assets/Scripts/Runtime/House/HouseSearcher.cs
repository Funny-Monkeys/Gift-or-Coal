using System.Linq;
using GiftOrCoal.Dossier;
using GiftOrCoal.Factories;
using GiftOrCoal.Factories.Kid;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.House
{
    public sealed class HouseSearcher : MonoBehaviour
    {
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private KidsFactory _kidsFactory;
        [SerializeField] private DossierView _dossierView;

        private bool _isHouseSearched;

        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down);

            if (hit.collider == null || !hit.collider.TryGetComponent(out HouseMovement _)) 
                return;

            if (!_isHouseSearched)
            {
                _housesFactory.SpawnedHoused.ToList().ForEach(Stop);
                _dossierView.Display(_kidsFactory.Create(KidType.Standard));
            }

            _isHouseSearched = true;
        }

        private void Stop(House house)
        {
            var houseMovement = house.Movement;
            
            if (houseMovement.CanMove)
                houseMovement.Stop();
        }
    }
}
