﻿using System.Linq;
using GiftOrCoal.Difficult;
using GiftOrCoal.Dossier;
using GiftOrCoal.Factories;
using GiftOrCoal.Other;
using GiftOrCoal.Santa;
using GiftOrCoal.Save;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class CoalButton : Buttons.Button
    {
        [SerializeField] private DossierView _dossierView;
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private Score.Score _score;
        [SerializeField] private Accuracy _accuracy;
        [SerializeField] private SantaAnimator _santaAnimator;
        [SerializeField] private SantaItemsFactory _santaItemsFactory;
        [SerializeField] private Telephone _telephone;
        [SerializeField] private SantaMovementEffect _santaMovementEffect;
        [SerializeField] private SledAnimator _sledAnimator;

        private readonly GameLoop.GameLoop _gameLoop = new();

        protected override void OnClick()
        {
            var currentKid = _dossierView.CurrentKid;
            var storage = new StorageWithNames<DifficultData, DifficultData>();
            var difficultData = storage.Load();
            _accuracy.AddAnswer();

            if (currentKid.Deeds.Count(deed => !deed.IsGood) > currentKid.Deeds.Count(deed => deed.IsGood))
            {
                _score.Add(difficultData.ScoreAddCount);
                _accuracy.AddSuccessfulAnswer();
            }
            else
            {
                var removeCount = difficultData.ScoreRemoveCount;
                _score.Remove(_score.CanRemove(removeCount) ? removeCount : _score.Count);
            }

            _sledAnimator.PlayFlightAnimation();
            _santaItemsFactory.CreateCoal(1);
            _gameLoop.Continue();
            _santaMovementEffect.MoveUp();
            _telephone.ToLoading();
            _santaAnimator.PlayClickAnimation();
            _housesFactory.SpawnedHoused.ToList().ForEach(house => house.Movement.ContinueMovement());
            _housesFactory.ContinueSpawn();
        }
    }
}