using UnityEngine;

namespace GiftOrCoal.KidData
{
    public class SpecialKidData : MonoBehaviour
    {
        [field: SerializeField] public KidData Data { get; private set; }
    }
}