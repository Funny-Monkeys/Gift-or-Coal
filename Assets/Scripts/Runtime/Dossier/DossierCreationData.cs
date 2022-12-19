using System.Collections.Generic;
using GiftOrCoal.Actions;

namespace GiftOrCoal.Dossier
{
    public class DossierCreationData
    {
        public readonly List<Deed> Deeds;
        public readonly string Name;
        
        public DossierCreationData(List<Deed> deeds, string name)
        {
            Deeds = deeds;
            Name = name;
        }
    }
}