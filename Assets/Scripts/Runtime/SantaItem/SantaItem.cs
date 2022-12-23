using GiftOrCoal.KidData;
using GiftOrCoal.Tools;
using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class SantaItem : MonoBehaviour, ISantaItem
    {
        [SerializeField] private AudioSource[] _dropSoundPrefabs;
        [SerializeField] private AudioSource[] _maleSoundPrefabs;
        [SerializeField] private AudioSource[] _femaleSoundPrefabs;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out House.House house))
            {
                var randomSoundPrefab = _dropSoundPrefabs[Random.Range(0, _dropSoundPrefabs.Length)];
                CreateSound(randomSoundPrefab);
                var gender = house.Kid.Data.Gender;
                
                CreateSound(gender == Gender.Male
                    ? _maleSoundPrefabs[Random.Range(0, _maleSoundPrefabs.Length)]
                    : _femaleSoundPrefabs[Random.Range(0, _femaleSoundPrefabs.Length)]);
                
                gameObject.SetActive(false);
            }
        }

        private void CreateSound(AudioSource randomSoundPrefab)
        {
            var sound = Instantiate(randomSoundPrefab);
            sound.Play();
            sound.DestroyOnPlayed().Forget();
        }
    }
}
