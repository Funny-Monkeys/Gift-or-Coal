using System.Linq;
using GiftOrCoal.Factories;
using GiftOrCoal.Santa;
using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class GiftButton : Buttons.Button
    {
        [SerializeField] private DossierView _dossierView;
        [SerializeField] private Score.Score _score;
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private Accuracy _accuracy;
        [SerializeField] private SantaAnimator _santaAnimator;
        
        private readonly GameLoop.GameLoop _gameLoop = new();

        protected override void OnClick()
        {
            var currentKid = _dossierView.CurrentKid;

            if (currentKid.Deeds.All(deed => deed.IsGood))
            {
                _score.Add(100);
                _accuracy.AddSuccessAnswer();
            }

            else if (_score.CanRemove(100))
            {
                _score.Remove(100);
                _accuracy.AddMistake();
            }

            _dossierView.Disable();
            _gameLoop.Continue();
            _santaAnimator.PlayClickAnimation();
            _housesFactory.SpawnedHoused.ToList().ForEach(house => house.Movement.ContinueMovement());
            _housesFactory.ContinueSpawn();
        }
    }
}