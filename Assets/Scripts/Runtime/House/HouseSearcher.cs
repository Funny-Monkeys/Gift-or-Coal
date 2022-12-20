using System.Linq;
using GiftOrCoal.Dossier;
using GiftOrCoal.Factories;
using GiftOrCoal.Factories.Kid;
using GiftOrCoal.House;
using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.Houses
{
    public sealed class HouseSearcher : MonoBehaviour
    {
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private DossierView _dossierView;
        [SerializeField] private KidsFactory _kidsFactory;
        private HouseMovement _lastSearchedHouse;
        
        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down);
            
            if(hit.collider != null && hit.collider.TryGetComponent(out HouseMovement houseMovement))
            {
                if(_lastSearchedHouse.transform == houseMovement.transform)
                    return;
                
                _housesFactory.StopSpawn();
                _housesFactory.SpawnedHoused.ToList().ForEach(Stop);
                _dossierView?.Display(_kidsFactory.Create(KidType.Standard));
                _lastSearchedHouse = houseMovement;
            }
        }

        private void Stop(House.House house)
        {
            var houseMovement = house.Movement;
            
            if (houseMovement.CanMove)
                houseMovement.Stop();
        }
    }
}
