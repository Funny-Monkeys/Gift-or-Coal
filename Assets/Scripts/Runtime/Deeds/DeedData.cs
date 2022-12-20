using UnityEngine;

namespace GiftOrCoal.Deeds
{
    [CreateAssetMenu(menuName = "Create/DeedData", fileName = "DeedData")]
    public class DeedData : ScriptableObject
    {
        [field: SerializeField] public string Text { get; private set; }
        [field: SerializeField] public bool IsGood { get; private set; }
    }
}