using System;
using GiftOrCoal.GameLoop;
using GiftOrCoal.LoadSystem;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class RestartButton : Button
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private SceneLoader _sceneLoader;
        
        private YandexSDK _yandexSDK;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        private void Awake()
        {
            _yandexSDK = YandexSDK.instance;

            if (_yandexSDK == null)
                throw new ArgumentNullException(nameof(YandexSDK));

            _yandexSDK.onInterstitialShown += OnShownInterstitial;
        }
        
        private void OnDestroy()
        {
            _yandexSDK.onInterstitialShown -= OnShownInterstitial;
        }

        private void OnShownInterstitial()
        {
            _gameLoop.Continue();
            _sceneLoader.Load(_sceneData);
        }

        protected override void OnClick()
        {
            _yandexSDK.ShowInterstitial();
            _gameLoop.Pause();
        }
    }
}