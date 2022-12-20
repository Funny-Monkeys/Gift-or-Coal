using System.Linq;
using GiftOrCoal.Factories;
using GiftOrCoal.House;
using UnityEngine;

namespace GiftOrCoal.Houses
{
    public sealed class HouseSearcher : MonoBehaviour
    {
        [SerializeField] private HousesFactory _housesFactory;

        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down);
            
            if(hit.collider != null && hit.collider.TryGetComponent(out HouseMovement _))
            {
                _housesFactory.SpawnedHoused.ToList().ForEach(Stop);
                _housesFactory.StopSpawn();
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
