using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GiftOrCoal.Save;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace GiftOrCoal.Tools.Localization
{
    public sealed class LanguagesDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        private readonly StorageWithNames<LanguagesDropdown, int> _lastSelectedIndexStorage = new();

        private async void OnEnable()
        {
            var languages = await AddLanguages();
            _dropdown.AddOptions(languages);
            _dropdown.onValueChanged.AddListener(SwitchLanguage);
            SwitchLanguage(_lastSelectedIndexStorage.HasSave() ? _lastSelectedIndexStorage.Load() : 0);
        }

        private void OnDestroy() => _dropdown.onValueChanged.RemoveListener(SwitchLanguage);

        private void SwitchLanguage(int index)
        {
            _dropdown.value = index;
            _dropdown.captionText.text = LocalizationSettings.AvailableLocales.Locales[index].LocaleName;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
            _lastSelectedIndexStorage.Save(index);
        }

        private async UniTask<List<TMP_Dropdown.OptionData>> AddLanguages()
        {
            await LocalizationSettings.InitializationOperation;
            var languages = new List<TMP_Dropdown.OptionData>();

            foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
            {
                var language = new TMP_Dropdown.OptionData(locale.LocaleName);
                languages.Add(language);
            }

            return languages;
        }
    }
}