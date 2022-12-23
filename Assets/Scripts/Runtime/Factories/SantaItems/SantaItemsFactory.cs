using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class SantaItemsFactory : MonoBehaviour
    {
        [SerializeField] private SantaItem _coalPrefab;
        [SerializeField] private SantaItem _giftPrefab;
        [SerializeField] private Transform _spawnPosition;
        
        public void CreateCoal(int count)
        {
            CreateItems(_coalPrefab, count);
        }
        
        public void CreateGift(int count)
        {
            CreateItems(_giftPrefab, count);
        }

        private void CreateItems(SantaItem santaItemPrefab, int count)
        {
            for (var i = 0; i < count; i++)
            {
                Instantiate(santaItemPrefab, _spawnPosition.position, Quaternion.identity);
            }
        }
    }
}