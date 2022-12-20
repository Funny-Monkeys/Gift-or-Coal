using System.Collections;
using System.Collections.Generic;
using GiftOrCoal.Factories.Kid;
using UnityEngine;

namespace GiftOrCoal.Factories
{
    public sealed class HousesFactory : MonoBehaviour
    {
        public IReadOnlyList<House.House> SpawnedHoused => _spawnedHouses;
        
        [SerializeField] private Transform _spawnPosition;
        [SerializeField, Min(0.1f)] private float _spawnDelay = 1.5f;

        [Space]
        [SerializeField] private List<House.House> _averageHouses;
        [SerializeField] private List<House.House> _specialHouses;
        [SerializeField] private RandomKidsFactory _kidsFactory;

        private readonly List<House.House> _spawnedHouses = new();
        private bool _canSpawn = true;
        
        private int _averageHousesCounter;
        private List<House.House> _notUsedSpecialHouses;

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
                House.House randomHouse;
                    
                if (_averageHousesCounter == 10)
                {
                    randomHouse = _notUsedSpecialHouses[Random.Range(0, _notUsedSpecialHouses.Count)];
                    _notUsedSpecialHouses.Remove(randomHouse);
                    _averageHousesCounter = 0;
                }
                else
                {
                    randomHouse = _averageHouses[Random.Range(0, _averageHouses.Count)];
                }
                 randomHouse.Init(_kidsFactory);   
                var spawnedHouse = Instantiate(randomHouse, _spawnPosition.position, randomHouse.transform.rotation, transform);
                _spawnedHouses.Add(spawnedHouse);
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