using GiftOrCoal.GameLoop;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class CloseCanvasButton : Button
    {
        [SerializeField] private Canvas _canvas;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        protected override void OnClick()
        {
            _canvas.gameObject.SetActive(false);
            _gameLoop.Continue();
        }
    }
}