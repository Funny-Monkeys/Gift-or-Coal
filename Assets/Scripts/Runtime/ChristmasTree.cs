using System;
using UnityEngine;

namespace GiftOrCoal
{
    public sealed class ChristmasTree : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _blinkOnStart;
        
        private readonly int _blinkId = Animator.StringToHash("Blink");

        private void OnEnable()
        {
            if(_blinkOnStart)
                Blink();
        }

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