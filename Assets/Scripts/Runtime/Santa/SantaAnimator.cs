using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GiftOrCoal.Santa
{
    [RequireComponent(typeof(Animator))]
    public sealed class SantaAnimator : MonoBehaviour
    {
        [SerializeField] private string[] _triggers;
        [SerializeField, Min(1f)] private float _secondsToPlayRandomAnimation = 30f;
        [SerializeField] private Animator _sledAnimator;
        
        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            PlayRandomAnimation().Forget();
        }

        private async UniTaskVoid PlayRandomAnimation()
        {
            while (true)
            {
                var trigger = _triggers[Random.Range(0, _triggers.Length)];
                _animator.SetTrigger(trigger);
                await UniTask.Delay(TimeSpan.FromSeconds(_secondsToPlayRandomAnimation));
            }
        }

        public void PlayClickAnimation()
        {
            _animator.Play("Click");
            _sledAnimator.Play("Flight");
        }
    }
}