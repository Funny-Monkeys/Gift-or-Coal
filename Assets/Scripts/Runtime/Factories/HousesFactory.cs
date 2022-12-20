using System.Collections;
using System.Collections.Generic;
using GiftOrCoal.Houses;
using UnityEngine;

namespace GiftOrCoal.Factories
{
    public sealed class HousesFactory : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField, Min(0.1f)] private float _spawnDelay = 1.5f;
        [SerializeField] private House.House _prefab;

        private readonly List<House.House> _spawnedHouses = new();

        public IReadOnlyList<House.House> SpawnedHoused => _spawnedHouses;
        
        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                var house = Instantiate(_prefab, _spawnPosition.position, _prefab.transform.rotation, transform);
                _spawnedHouses.Add(house);
            }
        }
    }
}