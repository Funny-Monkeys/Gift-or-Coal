using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories.Kid
{
    public class RandomDossierFactory : MonoBehaviour
    {
        [SerializeField] private List<string> _hobbies;
        [SerializeField] private List<string> _endsOfGreetings;

        private List<string> _notUsedHobbies = new();

        public string Create(string kidName)
        {
            _notUsedHobbies = new List<string>(_hobbies);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Hello, Santa Claus, my name is {kidName}. ");
            
            var hobbies = BuildHobbies();
            stringBuilder.Append($"I love {hobbies}. ");
            stringBuilder.Append($"{_endsOfGreetings[Random.Range(0, _endsOfGreetings.Count)]}. This year I have done these things:\n");
            
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
            
            return hobbies.Count switch
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