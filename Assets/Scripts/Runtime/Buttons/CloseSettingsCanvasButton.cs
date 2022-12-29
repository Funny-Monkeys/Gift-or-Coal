using GiftOrCoal.GameLoop;
using GiftOrCoal.Timer;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class CloseSettingsCanvasButton : Button
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private EndGameTimer _endGameTimer;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        protected override void OnClick()
        {
            _canvas.gameObject.SetActive(false);
            _endGameTimer.Continue();
            
            if (!_endGameTimer.FinishedCountdown)
                _gameLoop.Continue();
        }
    }
}