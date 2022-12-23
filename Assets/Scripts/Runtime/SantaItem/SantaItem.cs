using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class SantaItem : MonoBehaviour, ISantaItem
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<House.House>() != null)
                gameObject.SetActive(false);
        }
    }
}