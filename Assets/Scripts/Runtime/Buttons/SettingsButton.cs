using GiftOrCoal.GameLoop;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class SettingsButton : Button
    {
        [SerializeField] private Canvas _closingCanvas;
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();
        
        protected override void OnClick()
        {
           _closingCanvas.gameObject.SetActive(true);
           _gameLoop.Pause();
        }
    }
}
