using UnityEngine;

namespace GiftOrCoal.Background
{
    public sealed class Moon : MonoBehaviour
    {
        [SerializeField] public BackgroundView _background;

        private void Update()
        {
            if (_background.CurrentTimeOfDay == TimeOfDay.Morning)
                gameObject.SetActive(false);
        }
    }
}