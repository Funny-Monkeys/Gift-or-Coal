using GiftOrCoal.GameLoop;
using GiftOrCoal.Timer;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class SettingsButton : Button
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private ChristmasTree _christmasTree;
        [SerializeField] private EndGameTimer _endGameTimer;
        
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        protected override void OnClick()
        {
            _endGameTimer.Stop();
            _canvas.gameObject.SetActive(true);
            _gameLoop.Pause();
            _christmasTree.Blink();
        }
    }
}