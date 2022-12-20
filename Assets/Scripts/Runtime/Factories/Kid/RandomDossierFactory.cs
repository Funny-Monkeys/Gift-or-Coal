using System;
using System.Collections.Generic;
using System.Text;
using GiftOrCoal.Dossier;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories.Kid
{
    public class RandomDossierFactory : MonoBehaviour
    {
        [SerializeField] private List<string> _hobbies;
        [SerializeField] private List<string> _endsOfGreetings;

        private List<string> _notUsedHobbies = new();

        public string Create(DossierCreationData creationData)
        {
            _notUsedHobbies = new List<string>(_hobbies);
            var stringBuilder = new StringBuilder();
            
            var randomName = creationData.Name;
            stringBuilder.Append($"Hello, Santa Claus, my name is {randomName}. ");

            var hobbies = BuildHobbies();
            stringBuilder.Append($"I love {hobbies}. ");
            stringBuilder.Append($"{_endsOfGreetings[Random.Range(0, _endsOfGreetings.Count)]}. This year I have done these things:\n");
            
            for (var i = 0; i < creationData.Deeds.Count; i++)
                stringBuilder.Append($"{i + 1}) {creationData.Deeds[i].Text}\n");

            return stringBuilder.ToString();
        }
        
        private string BuildHobbies()
        {
            var hobbiesCount = Random.Range(1, _hobbies.Count);

            return hobbiesCount switch
            {
                1 => BuildHobby(),
                2 => $"{BuildHobby()} and {BuildHobby()}",
                3 => $"{BuildHobby()}, {BuildHobby()} and {BuildHobby()}",
                _ => throw new ArgumentOutOfRangeException($"HobbiesCount", "Too much hobbies")
            };
        }

        private string BuildHobby()
        {
            var generatedHobby = _notUsedHobbies[Random.Range(0, _notUsedHobbies.Count)];
            _notUsedHobbies.Remove(generatedHobby);
            return generatedHobby;
        }
    }
}