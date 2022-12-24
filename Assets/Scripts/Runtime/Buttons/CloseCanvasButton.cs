using GiftOrCoal.GameLoop;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class CloseCanvasButton : Button
    {
        [SerializeField] private Canvas _settingsCanvas;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        protected override void OnClick()
        {
            _settingsCanvas.gameObject.SetActive(false);
            if (Time.deltaTime != 0)
                _gameLoop.Continue();
        }
    }
}