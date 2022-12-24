namespace GiftOrCoal.GameLoop
{
    public interface IGameLoop
    {
        bool IsPaused { get; }
        
        void Pause();
        
        void Continue();
    }
}