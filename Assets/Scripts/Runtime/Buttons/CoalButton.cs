using System.Linq;
using Cysharp.Threading.Tasks;
using GiftOrCoal.Factories;
using GiftOrCoal.Other;
using GiftOrCoal.Santa;
using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class CoalButton : Buttons.Button
    {
        [SerializeField] private DossierView _dossierView;
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private Score.Score _score;
        [SerializeField] private Accuracy _accuracy;
        [SerializeField] private SantaAnimator _santaAnimator;
        [SerializeField] private SantaMovementEffect _santaMovementEffect;

        private readonly GameLoop.GameLoop _gameLoop = new();

        protected override void OnClick()
        {
            var currentKid = _dossierView.CurrentKid;

            if (currentKid.Deeds.Any(deed => !deed.IsGood))
            {
                _score.Add(100);
                _accuracy.AddSuccessAnswer();
            }

            else if (_score.CanRemove(100))
            {
                _score.Remove(100);
                _accuracy.AddMistake();
            }

            _gameLoop.Continue();
            _dossierView.Disable();
            _santaMovementEffect.MoveUp().Forget();

            _santaAnimator.PlayClickAnimation();
            _housesFactory.SpawnedHoused.ToList().ForEach(house => house.Movement.ContinueMovement());
            _housesFactory.ContinueSpawn();
        }
    }
}