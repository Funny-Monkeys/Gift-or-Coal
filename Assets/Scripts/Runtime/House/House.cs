using GiftOrCoal.KidData;
using UnityEngine;

namespace GiftOrCoal.House
{
    public sealed class House : MonoBehaviour
    {
        [field: SerializeField] public HouseMovement Movement { get; private set; }
        [field: SerializeField] public KidType KidType { get; private set; }
    }
}