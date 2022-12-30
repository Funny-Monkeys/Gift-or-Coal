using System;
using System.Collections.Generic;
using System.Linq;
using GiftOrCoal.KidData;
using GiftOrCoal.Tools.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace GiftOrCoal.Dossier
{
    public sealed class DossierView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dossierText;
        [SerializeField] private Image _kidPhoto;
        [SerializeField] private TMP_Text _deedTextPrefab;
        [SerializeField] private Transform _content;
        [SerializeField] private List<LocalizedString> _localizedStrings;

        public IKid CurrentKid { get; private set; }

        public void Display(IKid kid)
        {
            ClearContent();
            CurrentKid = kid;
            _dossierText.text = kid.Data.Dossier;
            var textLocalization = new TextLocalization(_localizedStrings);

            for (var i = 0; i < kid.Deeds.Count(); i++)
            {
                var deedText = Instantiate(_deedTextPrefab, _content);
                var text = kid.Deeds.ToList()[i].Text;

                try
                {
                    text = textLocalization.Localize(text);
                }
                
                catch (Exception)
                {
                }

                deedText.text = text;
                _kidPhoto.sprite = kid.Data.Photo;
            }
        }

        private void ClearContent()
        {
            for (var i = 0; i < _content.childCount; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}