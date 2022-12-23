using UnityEngine;

namespace GiftOrCoal.Santa
{
    public sealed class Santa : MonoBehaviour
    {
        public Vector2 Position => transform.position;
        
        public void TranslateToPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}