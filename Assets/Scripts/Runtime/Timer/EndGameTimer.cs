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
            _timerView.Display(_sessionTime - _time);
            _time += Time.unscaledDeltaTime;

            if (_time >= _sessionTime)
            {
                _time = 0;
                _endGamePanel.Enable();
                _gameLoop.Pause();
            }
        }
    }
}