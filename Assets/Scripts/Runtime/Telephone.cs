using UnityEngine;

namespace GiftOrCoal
{
    public sealed class Telephone : MonoBehaviour
    {
        [SerializeField] private ChristmasTree _christmasTree;

        private void Awake()
        {
            ToLoading();
        }

        public void ToLoading()
        {
            gameObject.SetActive(false);
            _christmasTree.Enable();
            _christmasTree.Blink();
        }

        public void ToStandard()
        {
            _christmasTree.StopBlink();
            _christmasTree.Disable();
            gameObject.SetActive(true);
        }
    }
}