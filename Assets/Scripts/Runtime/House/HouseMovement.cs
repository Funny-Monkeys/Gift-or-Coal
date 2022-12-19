using System;
using UnityEngine;

namespace GiftOrCoal.House
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class HouseMovement : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float _speed = 2.5f;
        private Rigidbody2D _rigidbody;

        public bool CanMove { get; private set; } = true;

        private void OnEnable()
        {
            _rigidbody ??= GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (CanMove)
                _rigidbody.MovePosition(_rigidbody.position + Vector2.left * (_speed * Time.fixedDeltaTime));
        }

        public void Stop()
        {
            var isStopped = CanMove == false;

            if (isStopped)
                throw new InvalidOperationException("Movement has already stopped!");

            CanMove = false;
        }

        public void ContinueMovement()
        {
            if (CanMove)
                throw new InvalidOperationException("Already can move!");

            CanMove = true;
        }
    }
}