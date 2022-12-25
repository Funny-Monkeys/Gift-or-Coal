using System;
using System.Collections.Generic;
using System.Linq;
using GiftOrCoal.Dossier;
using UnityEngine.Localization;

namespace GiftOrCoal.Tools
{
    public sealed class TextLocalization : ITextLocalization
    { 
        private readonly List<LocalizedString> _localizedStrings;

        public TextLocalization(List<LocalizedString> localizedStrings)
        {
            _localizedStrings = localizedStrings ?? throw new ArgumentNullException(nameof(localizedStrings));
        }

        public string Localize(LocalizationText text, string currentText)
        {
            if (text == null) 
                throw new ArgumentNullException(nameof(text));
            
            var localizedString = _localizedStrings.Find(line => line.ToString().Contains(currentText));
            text.LocalizeStringEvent.StringReference = localizedString;
            var localizedStringValue = localizedString.Values.ElementAt(0).ToString();
            text.SetValue(localizedStringValue);
            return localizedStringValue;
        }
    }
}