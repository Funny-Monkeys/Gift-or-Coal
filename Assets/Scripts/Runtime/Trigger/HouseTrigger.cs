using UnityEngine;

namespace GiftOrCoal.Trigger
{
    public class HouseTrigger : MonoBehaviour
    {
        [field: SerializeField] public House.House House { get; private set; }
    }
}