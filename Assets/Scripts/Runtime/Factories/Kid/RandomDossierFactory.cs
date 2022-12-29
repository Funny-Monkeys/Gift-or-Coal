using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiftOrCoal.Tools.Localization;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories.Kid
{
    public class RandomDossierFactory : MonoBehaviour
    {
        [SerializeField] private List<string> _hobbies;
        [SerializeField] private List<string> _endsOfGreetings;
        [SerializeField] private UnionsLocalization _unionsLocalization;
        [SerializeField] private DossierLocalization _dossierLocalization;
        
        private List<string> _notUsedHobbies = new();

        public string Create(string kidName)
        {
            kidName = _dossierLocalization.LocalizeName(kidName);
            _notUsedHobbies = new List<string>(_hobbies);
            var stringBuilder = new StringBuilder();
            var greeting = _dossierLocalization.LocalizeGreeting($"Hello, Santa Claus, my name is").Replace("{}", kidName);
            stringBuilder.Append(greeting);
            var hobbies = BuildHobbies();
            stringBuilder.Append(LocalizationSettings.SelectedLocale.LocaleName.Contains("English") ? $" I love: {hobbies}. " : $" Я люблю: {hobbies}. ");
            var localizedEndOfGreeting = _dossierLocalization.LocalizeEndOfGreeting(_endsOfGreetings[Random.Range(0, _endsOfGreetings.Count)]);
            stringBuilder.Append($"{localizedEndOfGreeting} {_dossierLocalization.LocalizeEndOfGreeting("This year I have done these things:")} \n");
            return stringBuilder.ToString();
        }
        
        private string BuildHobbies()
        {
            var hobbiesCount = 3;
            var hobbies = new List<string>(hobbiesCount);

            for (var i = 0; i < hobbiesCount; i++)
            {
                hobbies.Add(_hobbies[Random.Range(0, _hobbies.Count)]);
            }

            hobbies = hobbies.Distinct().ToList();
            var and = _unionsLocalization.Localize("And");

            return hobbies.Count switch
            {
                1 => BuildHobby(),
                2 => $"{BuildHobby()} {and} {BuildHobby()}",
                3 => $"{BuildHobby()}, {BuildHobby()} {and} {BuildHobby()}",
                _ => throw new ArgumentOutOfRangeException($"HobbiesCount", "Too much hobbies")
            };
        }

        private string BuildHobby()
        {
            var generatedHobby = _notUsedHobbies[Random.Range(0, _notUsedHobbies.Count)];
            _notUsedHobbies.Remove(generatedHobby);
            return _dossierLocalization.LocalizeHobby(generatedHobby);
        }
    }
}