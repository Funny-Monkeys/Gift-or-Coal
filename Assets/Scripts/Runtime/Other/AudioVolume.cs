using GiftOrCoal.Save;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GiftOrCoal.Other
{
    public class AudioVolume : MonoBehaviour
    {
        [SerializeField] private AudioMixer _soundMixer;
        [SerializeField, Tooltip("Can be null")] private CountView _countView;

        private readonly StorageWithNameSaveObject<AudioVolume, float> _storage = new();
        private const string GroupName = "Master";
        private const float DefaultValue = 0.5f;

        [field: SerializeField, Tooltip("Can be null")] public Slider Slider { get; private set; }

        private void Awake() => Init();

        private void Init()
        {
            if (Slider != null)
                Slider.onValueChanged.AddListener(ChangeSoundVolume);
            
            var value = _storage.HasSave() ? _storage.Load() : DefaultValue;
            ChangeSoundVolume(value);
        }

        private void OnDisable()
        {
            if (Slider != null)
                Slider.onValueChanged.RemoveListener(ChangeSoundVolume);
        }

        private void ChangeSoundVolume(float value)
        {
            _soundMixer.SetFloat(GroupName, ToVolume(value));
            _storage.Save(value);
            
            if (Slider != null)
                Slider.value = value;
            
            if (_countView != null)
                _countView.Visualize(Mathf.RoundToInt(value * 100f));
        }

        private float ToVolume(float value) => Mathf.Lerp(-50, 20, value);
    }
}