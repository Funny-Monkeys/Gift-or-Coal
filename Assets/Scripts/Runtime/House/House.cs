using UnityEngine;

namespace GiftOrCoal.Houses
{
    public sealed class House : MonoBehaviour
    {
        [field: SerializeField] public HouseMovement Movement { get; private set; }
        
        [field: SerializeField] public KidType KidType { get; private set; }
    }
}