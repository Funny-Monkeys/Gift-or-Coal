using UnityEngine;

namespace GiftOrCoal.Timer
{
    public sealed class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private ChristmasTree _christmasTree;
        
        public void Enable()
        {
            gameObject.SetActive(true);
            _christmasTree.Blink();
        }
    }
}