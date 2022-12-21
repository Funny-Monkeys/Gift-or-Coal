using System.Linq;
using GiftOrCoal.KidData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GiftOrCoal.Dossier
{
    public sealed class DossierView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _dossierText;
        [SerializeField] private Image _kidPhoto;
        [SerializeField] private TMP_Text _deedTextPrefab;
        [SerializeField] private Transform _content;

        public IKid CurrentKid { get; private set; }

        public void Display(IKid kid)
        {
            ClearContext();
            
            CurrentKid = kid;
            _nameText.text = kid.Data.Name;
            _dossierText.text = kid.Data.Dossier;

            for (var i = 0; i < kid.Deeds.Count(); i++)
            {
                var deedText = Instantiate(_deedTextPrefab, _content);
                deedText.text = $"{i + 1}) {kid.Deeds.ToList()[i].Text}";
            }

            _kidPhoto.sprite = kid.Data.Photo;
        }

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        private void ClearContext()
        {
            for (var i = 0; i < _content.childCount; i++)
                 Destroy(_content.GetChild(0).gameObject);
        }
    }
}