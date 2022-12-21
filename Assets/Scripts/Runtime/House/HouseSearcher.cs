using System.Linq;
using GiftOrCoal.Dossier;
using GiftOrCoal.Factories;
using GiftOrCoal.Factories.Kid;
using UnityEngine;

namespace GiftOrCoal.Houses
{
    public sealed class HouseSearcher : MonoBehaviour
    {
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private Dossier.Dossier _dossier;
        private House.House _lastSearchedHouse;

        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down);
            
            if (hit.collider != null && hit.collider.TryGetComponent(out House.House houseMovement))
            {
                if(_lastSearchedHouse != null && _lastSearchedHouse.transform == houseMovement.transform)
                    return;
                
                _lastSearchedHouse = houseMovement;
                _housesFactory.StopSpawn();
                _housesFactory.SpawnedHoused.ToList().ForEach(Stop);
                _dossier.View.Enable();
                var kid = _lastSearchedHouse.CreateKid();
                _dossier.View.Display(kid);
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
