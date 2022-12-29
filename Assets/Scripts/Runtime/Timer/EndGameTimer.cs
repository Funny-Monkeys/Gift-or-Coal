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
        private bool _isStopped;
        private float _time;
        
        public bool FinishedCountdown => _time >= _sessionTime;
        
        private void Update()
        {
            if (FinishedCountdown || _isStopped)
                return;
            
            _timerView.Display(_sessionTime - _time);
            _time += Time.unscaledDeltaTime;

            if (FinishedCountdown)
            {
                _endGamePanel.Enable();
                _gameLoop.Pause();
            }
        }

        public void Stop() => _isStopped = true;

        public void Continue() => _isStopped = false;
        
    }
}