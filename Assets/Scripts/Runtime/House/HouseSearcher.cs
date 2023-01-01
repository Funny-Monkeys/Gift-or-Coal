using System.Linq;
using GiftOrCoal.Dossier;
using GiftOrCoal.Factories;
using GiftOrCoal.GameLoop;
using GiftOrCoal.Santa;
using GiftOrCoal.Trigger;
using UnityEngine;

namespace GiftOrCoal.Houses
{
    public sealed class HouseSearcher : MonoBehaviour
    {
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private DossierView _dossierView;
        [SerializeField] private SantaMovementEffect _santaMovementEffect;
        [SerializeField] private Telephone _telephone;
        [SerializeField] private SledAnimator _sledAnimator;

        private HouseTrigger _lastSearchedHouseTrigger;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down);

            if (hit.collider != null && hit.collider.TryGetComponent(out MoveDownTrigger _))
                _santaMovementEffect.MoveDown();

            if (hit.collider == null || !hit.collider.TryGetComponent(out HouseTrigger house)) 
                return;
            
            if (_lastSearchedHouseTrigger != null && _lastSearchedHouseTrigger.transform == house.transform)
                return;
                
            _sledAnimator.PlayStayingAnimation();
            _telephone.ToStandard();
            _lastSearchedHouseTrigger = house;
            _gameLoop.Pause();
            _housesFactory.StopSpawn();
            _housesFactory.SpawnedHoused.ToList().ForEach(Stop);
            var kid = _lastSearchedHouseTrigger.House.CreateKid();
            _dossierView.Display(kid);
        }

        private void Stop(House.House house)
        {
            var houseMovement = house.Movement;
            
            if (houseMovement.CanMove)
                houseMovement.Stop();
        }
    }
}
