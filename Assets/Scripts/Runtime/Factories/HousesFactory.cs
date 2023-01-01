using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GiftOrCoal.Background;
using GiftOrCoal.KidData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Factories
{
    public sealed class HousesFactory : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private BackgroundView _backgroundView;
        [SerializeField, Min(0.1f)] private float _spawnDelay = 1.5f;
        [SerializeField] private List<House.House> _averageHouses;
        [SerializeField] private House.House _specialHouse;

        private readonly List<House.House> _spawnedHouses = new();

        private int _averageHousesCounter;
        private List<KidType> _notUsedKidTypes;

        public bool CanSpawn { get; private set; } = true;
        
        public IReadOnlyList<House.House> SpawnedHoused => _spawnedHouses;
        
        private void Awake()
        {
            _notUsedKidTypes = Enum.GetValues(typeof(KidType)).Cast<KidType>().ToList();
            _notUsedKidTypes.Remove(KidType.Standard);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (CanSpawn)
            {
                yield return new WaitForSeconds(_spawnDelay);
                if (!CanSpawn) 
                    StartCoroutine(Spawn());
                
                _averageHousesCounter++;
                House.House randomHousePrefab;
                var kidType = KidType.Standard;
                    
                if (_averageHousesCounter == 5)
                {
                    randomHousePrefab = _specialHouse;
                    kidType = _notUsedKidTypes[Random.Range(0, _notUsedKidTypes.Count)];
                    
                    _notUsedKidTypes.Remove(kidType);
                    _averageHousesCounter = 0;
                }
                else
                {
                    randomHousePrefab = _averageHouses[Random.Range(0, _averageHouses.Count)];
                }
                
                var house = Instantiate(randomHousePrefab, _spawnPosition.position, randomHousePrefab.transform.rotation, transform);
                house.Init(kidType, _backgroundView.CurrentTimeOfDay);
                house.TurnOnAttributes();
                _spawnedHouses.Add(house);
            }
        }

        public void StopSpawn() => CanSpawn = false;

        public void ContinueSpawn() => CanSpawn = true;
        
    }
}