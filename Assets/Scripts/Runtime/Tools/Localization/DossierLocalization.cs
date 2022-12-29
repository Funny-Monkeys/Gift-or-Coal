using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace GiftOrCoal.Tools.Localization
{
    public sealed class DossierLocalization : MonoBehaviour
    {
        [SerializeField] private List<LocalizedString> _localizedHobbies;
        [SerializeField] private List<LocalizedString> _localizedNames;
        [SerializeField] private List<LocalizedString> _localizedEndOfGreetings;
        [SerializeField] private List<LocalizedString> _localizedGreetings;

        public string LocalizeHobby(string text) => Localize(text, _localizedHobbies);

        public string LocalizeName(string text) => Localize(text, _localizedNames);

        public string LocalizeGreeting(string text) => Localize(text, _localizedGreetings);

        public string LocalizeEndOfGreeting(string text) => Localize(text, _localizedEndOfGreetings);

        private string Localize(string text, List<LocalizedString> localizedStrings)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            Debug.Log(text);

            return new TextLocalization(localizedStrings).Localize(text);
        }
    }
}