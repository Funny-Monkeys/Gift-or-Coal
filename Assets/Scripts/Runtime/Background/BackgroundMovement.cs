using UnityEngine;

namespace GiftOrCoal.Background
{
    public class BackgroundMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void FixedUpdate() => transform.Translate(Vector3.left * (_speed * Time.deltaTime));
    }
}