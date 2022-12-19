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

        public void Display(KidData.Kid kid)
        {
            _nameText.text = kid.Data.Name;
            _dossierText.text = kid.Data.Dossier;
            _kidPhoto.sprite = kid.Data.Photo;
        }
    }
}