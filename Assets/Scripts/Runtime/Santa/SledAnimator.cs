using UnityEngine;

namespace GiftOrCoal.Santa
{
    [RequireComponent(typeof(Animator))]
    public sealed class SledAnimator : MonoBehaviour
    {
        private readonly int _flying = Animator.StringToHash("Flying");
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            PlayFlightAnimation();
        }

        private void PlayFlightAnimation()
        {
            _animator.SetBool(_flying, true);
        }
    }
}