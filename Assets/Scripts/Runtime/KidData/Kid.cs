using System.Collections.Generic;
using GiftOrCoal.Deeds;

namespace GiftOrCoal.KidData
{
    public sealed class Kid : IKid
    {
        public Kid(KidData data, IEnumerable<Deed> deeds)
        {
            Data = data;
            Deeds = deeds;
        }

        public KidData Data { get; }
        
        public IEnumerable<Deed> Deeds { get; }
        
    }
}