using System.Collections.Generic;
using GiftOrCoal.Deeds;

namespace GiftOrCoal.KidData
{
    public sealed class Kid
    {
        public readonly KidData Data;
        public readonly List<Deed> Deeds;

        public Kid(KidData data, List<Deed> deeds)
        {
            Data = data;
            Deeds = deeds;
        }
    }
}