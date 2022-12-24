using GiftOrCoal.GameLoop;
using GiftOrCoal.LoadSystem;
using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public class RestartButton : Button
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private SceneLoader _sceneLoader;
        
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();
        
        protected override void OnClick()
        {
            _gameLoop.Continue();
            _sceneLoader.Load(_sceneData);
        }
    }
}