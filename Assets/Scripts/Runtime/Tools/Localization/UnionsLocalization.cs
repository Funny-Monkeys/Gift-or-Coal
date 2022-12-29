using System;
using System.Collections.Generic;
using GiftOrCoal.Tools;
using UnityEngine;
using UnityEngine.Localization;

namespace GiftOrCoal.Tools.Localization
{
    public sealed class UnionsLocalization : MonoBehaviour
    {
        [SerializeField] private List<LocalizedString> _localizedUnions;

        public string Localize(string union)
        {
            if (union == null) 
                throw new ArgumentNullException(nameof(union));
            
            return new TextLocalization(_localizedUnions).Localize(union);
        }
    }
}