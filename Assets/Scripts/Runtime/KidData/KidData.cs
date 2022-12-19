using UnityEngine;

namespace GiftOrCoal.KidData
{
    public struct KidData
    {
        public readonly string Name;
        public readonly string Dossier;
        public readonly Sprite Photo;

        public KidData(string name, string dossier, Sprite photo)
        {
            Dossier = dossier;
            Name = name;
            Photo = photo;
        }
    }
}