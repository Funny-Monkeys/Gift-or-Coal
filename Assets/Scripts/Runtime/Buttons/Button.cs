using UnityEngine;

namespace GiftOrCoal.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class Button : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;

        private void OnEnable()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}