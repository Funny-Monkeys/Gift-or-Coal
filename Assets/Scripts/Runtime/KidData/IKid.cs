using System.Collections.Generic;
using GiftOrCoal.Deeds;

namespace GiftOrCoal.KidData
{
    public interface IKid
    {
        KidData Data { get; }
        
        List<Deed> Deeds { get; }
    }
}