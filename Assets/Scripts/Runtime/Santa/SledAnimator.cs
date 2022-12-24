using UnityEngine;

namespace GiftOrCoal.Santa
{
    [RequireComponent(typeof(Animator))]
    public sealed class SledAnimator : MonoBehaviour
    {
        private readonly int _staying = Animator.StringToHash("Staying");
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            PlayFlightAnimation();
        }

        public void PlayStayingAnimation()
        {
            _animator.SetBool(_staying, true);
        }
        
        public void PlayFlightAnimation()
        {
            _animator.SetBool(_staying, false);
            _animator.Play("Flight");
        }
    }
}