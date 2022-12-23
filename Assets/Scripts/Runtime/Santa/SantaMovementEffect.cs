using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GiftOrCoal.Santa
{
    public sealed class SantaMovementEffect : MonoBehaviour
    {
        [SerializeField] private Santa _santa;
        [SerializeField, Min(1f)] private float _maxHeight = 5f;
        
        private const float TimeToNextHouse = 3f;
        private const float HalfTimeToNextHouse = TimeToNextHouse / 2f;
        private float _minHeight;
        
        private void Start()
        {
            _minHeight = _santa.Position.y;
            PlayEffect().Forget();
        }

        private async UniTaskVoid PlayEffect()
        {
            var time = 0f;
            
            while (true)
            {
                if (time < HalfTimeToNextHouse)
                {
                    var nextPosition = Vector2.Lerp(_santa.Position, new Vector2(_santa.Position.x, _maxHeight), time / TimeToNextHouse);
                    _santa.TranslateToPosition(nextPosition);
                }
                
                else
                {
                    var nextPosition = Vector2.Lerp(_santa.Position, new Vector2(_santa.Position.x, _minHeight), time / TimeToNextHouse);
                    _santa.TranslateToPosition(nextPosition);

                    if (time > TimeToNextHouse)
                        time = 0f;
                }

                time += Time.deltaTime;
                await UniTask.Yield();
            }
        }
    }
}
