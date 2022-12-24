using GiftOrCoal.GameLoop;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class SettingsButton : Button
    {
        [SerializeField] private Canvas _closingCanvas;
        [SerializeField] private ChristmasTree _christmasTree;

        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();

        protected override void OnClick()
        {
            if(Time.timeScale == 0)
                return;
            
            _christmasTree.Blink();
            _closingCanvas.gameObject.SetActive(true);
            _gameLoop.Pause();
        }
    }
}