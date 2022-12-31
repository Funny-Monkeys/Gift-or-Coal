using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

namespace GiftOrCoal.Tools.Localization
{
    public sealed class TextLocalization : ITextLocalization
    { 
        private readonly IReadOnlyList<LocalizedString> _localizedStrings;

        public TextLocalization(IReadOnlyList<LocalizedString> localizedStrings)
        {
            _localizedStrings = localizedStrings ?? throw new ArgumentNullException(nameof(localizedStrings));
        }
        
        public string Localize(string currentText)
        {
            var localizedString = _localizedStrings.ToList().Find(line => line.ToString().Contains(currentText));

            if (localizedString == null)
                return string.Empty;
            
            Debug.Log(currentText);
            return localizedString.GetLocalizedString();
        }
    }
}