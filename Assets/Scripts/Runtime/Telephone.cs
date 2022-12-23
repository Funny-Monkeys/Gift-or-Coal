using UnityEngine;
using UnityEngine.UI;

namespace GiftOrCoal
{
    public sealed class Telephone : MonoBehaviour
    {
        [SerializeField] private ChristmasTree _christmasTree;
        [SerializeField] private Sprite _loadingSprite;
        [SerializeField] private Sprite _standardSprite;
        [SerializeField] private Image _image;
        
        private void Awake()
        {
            ToLoading();
        }

        public void ToLoading()
        {
            _image.sprite = _loadingSprite;
            gameObject.SetActive(false);
            _christmasTree.Enable();
            _christmasTree.Blink();
        }

        public void ToStandard()
        {
            _image.sprite = _standardSprite;
            _christmasTree.StopBlink();
            _christmasTree.Disable();
            gameObject.SetActive(true);
        }
    }
}