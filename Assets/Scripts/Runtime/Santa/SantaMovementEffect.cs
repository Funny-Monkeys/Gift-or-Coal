using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GiftOrCoal.Santa
{
    public sealed class SantaMovementEffect : MonoBehaviour
    {
        [SerializeField] private Transform _santa;
        [SerializeField, Min(1f)] private float _maxHeight = 5f;
        [SerializeField] private float _changingTime;
        private float _minHeight;

        private void Awake()
        {
            _minHeight = _santa.position.y;
            MoveUp();
        }

        public void MoveUp()
        {
            MoveTo(_maxHeight).Forget();
        }

        public void MoveDown()
        {
            MoveTo(_minHeight).Forget();
        }
        
        private async UniTaskVoid MoveTo(float positionY)
        {
            var timer = 0f;
            var startPosition = _santa.position;

            while (timer < _changingTime)
            {
                timer += Time.deltaTime;
                
                if(_santa == null)
                    return;
                
                var nextPosition = Vector2.Lerp(startPosition, new Vector2(_santa.position.x, positionY), timer / _changingTime);
                _santa.transform.position = nextPosition;
                await UniTask.Yield();
            }
        }
    }
}
