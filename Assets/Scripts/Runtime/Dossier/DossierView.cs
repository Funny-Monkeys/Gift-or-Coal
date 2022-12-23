using System.Linq;
using GiftOrCoal.KidData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GiftOrCoal.Dossier
{
    public sealed class DossierView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dossierText;
        [SerializeField] private Image _kidPhoto;
        [SerializeField] private TMP_Text _deedTextPrefab;
        [SerializeField] private Transform _content;

        public IKid CurrentKid { get; private set; }

        public void Display(IKid kid)
        {
            ClearContent();
            CurrentKid = kid;
            _dossierText.text = kid.Data.Dossier;

            for (var i = 0; i < kid.Deeds.Count(); i++)
            {
                var deedText = Instantiate(_deedTextPrefab, _content);
                deedText.text = $"{i + 1}) {kid.Deeds.ToList()[i].Text}";
            }

            _kidPhoto.sprite = kid.Data.Photo;
        }

        private void ClearContent()
        {
            for (var i = 0; i < _content.childCount; i++)
                 Destroy(_content.GetChild(i).gameObject);
        }
    }
}