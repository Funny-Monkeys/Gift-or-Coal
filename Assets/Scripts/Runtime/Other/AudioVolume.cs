using GiftOrCoal.Save;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GiftOrCoal.Other
{
    public class AudioVolume : MonoBehaviour
    {
        [SerializeField] private AudioMixer _soundMixer;
        [SerializeField] private CountView _countView;
        
        private readonly StorageWithNameSaveObject<AudioVolume, float> _storage = new ();
        private const string GroupName = "Master";
        private const float DefaultValue = 0.5f;

        [field: SerializeField] public Slider Slider { get; private set; }
    
        private void Start() => Init();

        private void Init()
        {
            Slider.onValueChanged.AddListener(ChangeSoundVolume);
            var value = _storage.HasSave() ? _storage.Load() : DefaultValue;
            ChangeSoundVolume(value);
        }

        private void OnDisable() => Slider.onValueChanged.RemoveListener(ChangeSoundVolume);

        private void ChangeSoundVolume(float value)
        {
            _soundMixer.SetFloat(GroupName, ToVolume(value));
            Slider.value = value;
            _storage.Save(value);
            _countView.Visualize(Mathf.RoundToInt(value * 100f));
        }

        private float ToVolume(float value) => Mathf.Lerp(-100, 0, value);
    
    }
}
