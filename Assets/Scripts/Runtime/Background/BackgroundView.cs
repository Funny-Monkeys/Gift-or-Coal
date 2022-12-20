using System.Collections.Generic;
using UnityEngine;

namespace GiftOrCoal.Background
{
    public class BackgroundView : MonoBehaviour, IBackgroundView
    {
        [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
        [SerializeField] private List<Sprite> _backgrounds;
        private Sprite _currentBackground;

        public void Display()
        {
            var generatedBackground = _backgrounds[Random.Range(0, _backgrounds.Count)];
            
            while (generatedBackground == _currentBackground)
                generatedBackground = _backgrounds[Random.Range(0, _backgrounds.Count)];

            _currentBackground = generatedBackground;
            _backgroundSpriteRenderer.sprite = _currentBackground;
        }

        private void Awake() => Display();
    }
}