using UnityEngine;

namespace GiftOrCoal
{
    public sealed class ChristmasTree : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private readonly int _blinkId = Animator.StringToHash("Blink");
        
        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        public void Blink()
        {
            _animator.SetBool(_blinkId, true);
        }

        public void StopBlink()
        {
            _animator.SetBool(_blinkId, false);
        }
    }
}