using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GiftOrCoal.Background
{
    public class BackgroundView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tempSpriteRenderer;
        [SerializeField] private SpriteRenderer _activeSpriteRenderer;
         
        [Space] [SerializeField] private List<Sprite> _backgrounds;
        [Space] [SerializeField] private int _timeForOneBackground;
        [SerializeField] private float _changingTimeInMilliseconds;
        
        private int _currentBackgroundIndex;
        private const int MillisecondsInSeconds = 1000;

        public TimeOfDay CurrentTimeOfDay => (TimeOfDay)_currentBackgroundIndex;

        private async void Awake() => await StartDisplaying();

        private async UniTask StartDisplaying()
        {
            while (true)
            {
                await UniTask.Delay(_timeForOneBackground * MillisecondsInSeconds);
                
                if(_activeSpriteRenderer == null)
                    return;
                
                if (_currentBackgroundIndex == _backgrounds.Count)
                    break;
                
                var newSprite = _backgrounds[_currentBackgroundIndex];
                _tempSpriteRenderer.sprite = newSprite;
                _currentBackgroundIndex++;
                float timer = 0;
                var changingTimeInSeconds = _changingTimeInMilliseconds / MillisecondsInSeconds;
                
                while (timer < changingTimeInSeconds)
                {
                    _activeSpriteRenderer.color = new Color(_activeSpriteRenderer.color.r, 
                        _activeSpriteRenderer.color.g, 
                        _activeSpriteRenderer.color.b, 
                        Mathf.Lerp(1, 0, timer / changingTimeInSeconds));

                    _tempSpriteRenderer.color = new Color(_tempSpriteRenderer.color.r, 
                        _tempSpriteRenderer.color.g, 
                        _tempSpriteRenderer.color.b, 
                        Mathf.Lerp(0, 1, timer / changingTimeInSeconds));

                    timer += Time.fixedUnscaledDeltaTime;
                    await UniTask.WaitForFixedUpdate();
                }

                _activeSpriteRenderer.sprite = newSprite;
            }
        }
    }
}