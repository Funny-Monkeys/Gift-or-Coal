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
    public sealed class GiftButton : Buttons.Button
    {
        [SerializeField] private DossierView _dossierView;
        [SerializeField] private Score.Score _score;
        [SerializeField] private HousesFactory _housesFactory;
        [SerializeField] private Accuracy _accuracy;
        [SerializeField] private SantaAnimator _santaAnimator;
        [SerializeField] private SantaItemsFactory _santaItemsFactory;
        [SerializeField] private Telephone _telephone;
        [SerializeField] private SantaMovementEffect _santaMovementEffect;
        [SerializeField] private AudioSource _soundOnPressed;
        [SerializeField] private SledAnimator _sledAnimator;

        private readonly GameLoop.GameLoop _gameLoop = new();

        protected override void OnClick()
        {
            var currentKid = _dossierView.CurrentKid;
            var storage = new StorageWithNameSaveObject<DifficultData, DifficultData>();
            var difficultData = storage.Load();
            
            if (currentKid.Deeds.Count(deed => deed.IsGood) >= currentKid.Deeds.Count(deed => deed.IsGood))
            {
                _score.Add(difficultData.ScoreAddCount);
            }
            else
            {
                var removeCount = difficultData.ScoreRemoveCount;
                _score.Remove(_score.CanRemove(removeCount) ? removeCount : _score.Count);
                _accuracy.AddMistake();
            }

            _accuracy.AddAnswer();
            _sledAnimator.PlayStayingAnimation();
            _santaItemsFactory.CreateGift(Random.Range(1, 3));
            _gameLoop.Continue();
            _santaMovementEffect.MoveUp();
            _soundOnPressed.Play();
            _telephone.ToLoading();
            _santaAnimator.PlayClickAnimation();
            _housesFactory.SpawnedHoused.ToList().ForEach(house => house.Movement.ContinueMovement());
            _housesFactory.ContinueSpawn();
        }
    }
}