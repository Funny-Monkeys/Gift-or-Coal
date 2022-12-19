using UnityEngine;

namespace GiftOrCoal.GameLoop
{
    public sealed class GameLoop : IGameLoop
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Continue()
        {
            Time.timeScale = 1;
        }
    }
}