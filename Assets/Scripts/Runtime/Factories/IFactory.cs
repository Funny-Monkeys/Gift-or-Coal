namespace GiftOrCoal.LoadSystem
{
    public interface IFactory<out T>
    {
        T Create();
    }
}