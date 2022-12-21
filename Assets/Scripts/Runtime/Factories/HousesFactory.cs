using System.Collections;
using System.Collections.Generic;
using GiftOrCoal.Factories.Kid;
using UnityEngine;

namespace GiftOrCoal.Factories
{
    public sealed class HousesFactory : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField, Min(0.1f)] private float _spawnDelay = 1.5f;

        [Space]
        [SerializeField] private List<House.House> _averageHouses;
        [SerializeField] private List<House.House> _specialHouses;

        private readonly List<House.House> _spawnedHouses = new();
        private bool _canSpawn = true;
        
        private int _averageHousesCounter;
        private List<House.House> _notUsedSpecialHouses;

        public IReadOnlyList<House.House> SpawnedHoused => _spawnedHouses;
        
        private void Awake()
        {
            _notUsedSpecialHouses = new List<House.House>(_specialHouses);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_canSpawn)
            {
                yield return new WaitForSeconds(_spawnDelay);

                if (!_canSpawn) 
                    continue;
                
                _averageHousesCounter++;
                House.House randomHousePrefab;
                    
                if (_averageHousesCounter == 10)
                {
                    randomHousePrefab = _notUsedSpecialHouses[Random.Range(0, _notUsedSpecialHouses.Count)];
                    _notUsedSpecialHouses.Remove(randomHousePrefab);
                    _averageHousesCounter = 0;
                }
                else
                {
                    randomHousePrefab = _averageHouses[Random.Range(0, _averageHouses.Count)];
                }
                
                var house = Instantiate(randomHousePrefab, _spawnPosition.position, randomHousePrefab.transform.rotation, transform);
                _spawnedHouses.Add(house);
            }
        }

        public void StopSpawn() => _canSpawn = false;

        public void ContinueSpawn()
        {
            _canSpawn = true;
            StartCoroutine(Spawn());
        }
    }
}