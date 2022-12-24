using UnityEngine;

namespace GiftOrCoal.GameLoop
{
    public sealed class GameLoop : IGameLoop
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0;
        }

        public void Continue()
        {
            IsPaused = false;
            Time.timeScale = 1;
        }
    }
}