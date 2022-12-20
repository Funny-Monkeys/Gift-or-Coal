using System;
using System.Linq;
using GiftOrCoal.Factories;
using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class GiftButton : Buttons.Button
    {
        [SerializeField] private DossierView _dossierView;
        private Score.Score _score;
        private HousesFactory _housesFactory;

        public void Init(Score.Score score, HousesFactory housesFactory)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _housesFactory = housesFactory ?? throw new ArgumentNullException(nameof(housesFactory));
        }

        protected override void OnClick()
        {
            var currentKid = _dossierView.CurrentKid;

            if (currentKid.Deeds.All(deed => deed.IsGood))
            {
                _score.Add(100);
            }

            else if (_score.CanRemove(100))
            {
                _score.Remove(100);
            }
            
            _dossierView.Disable();
            _housesFactory.SpawnedHoused.ToList().ForEach(house => house.Movement.ContinueMovement());
            _housesFactory.ContinueSpawn();
        }
    }
}