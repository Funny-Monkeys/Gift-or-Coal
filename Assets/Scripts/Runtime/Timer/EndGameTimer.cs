using GiftOrCoal.GameLoop;
using UnityEngine;

namespace GiftOrCoal.Timer
{
    public sealed class EndGameTimer : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float _sessionTime = 180f;
        [SerializeField] private EndGamePanel _endGamePanel;
        [SerializeField] private TimerView _timerView;
        
        private readonly IGameLoop _gameLoop = new GameLoop.GameLoop();
        private float _time;
        
        private void Update()
        {
            _time += Time.deltaTime;
            _timerView.Display((int)(_sessionTime - _time));

            if (!(_time >= _sessionTime)) 
                return;
            
            _time = 0;
            _endGamePanel.Enable();
            _gameLoop.Pause();
        }
    }
}