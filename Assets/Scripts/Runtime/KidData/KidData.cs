﻿using System;
using UnityEngine;

namespace GiftOrCoal.KidData
{
    [Serializable]
    public struct KidData
    {
        [field: SerializeField] public Sprite Photo { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, TextArea] public string Dossier { get; private set; }

        public KidData(string name, string dossier, Sprite photo)
        {
            Dossier = dossier;
            Name = name;
            Photo = photo;
        }
    }
}