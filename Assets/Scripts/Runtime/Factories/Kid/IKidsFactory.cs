using GiftOrCoal.KidData;

namespace GiftOrCoal.Factories.Kid
{
    public interface IKidsFactory<T>
    {
        T Create(KidType kidType);
    }
}