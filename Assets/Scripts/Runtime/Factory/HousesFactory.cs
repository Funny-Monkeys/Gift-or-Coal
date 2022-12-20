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
        [SerializeField] private House _prefab;

        private readonly List<House> _spawnedHouses = new();
        private bool _canSpawn = true;

        public IReadOnlyList<House> SpawnedHoused => _spawnedHouses;
        
        private void Start() => StartCoroutine(Spawn());

        private IEnumerator Spawn()
        {
            while (_canSpawn)
            {
                yield return new WaitForSeconds(_spawnDelay);
                var house = Instantiate(_prefab, _spawnPosition.position, _prefab.transform.rotation, transform);
                _spawnedHouses.Add(house);
            }
        }

        public void StopSpawn()
        {
            _canSpawn = false;
        }
        
        public void ContinueSpawn()
        {
            _canSpawn = true;
            StartCoroutine(Spawn());
        }
    }
}