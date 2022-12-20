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

        public Kid CurrentKid { get; private set; }

        public void Display(Kid kid)
        {
            CurrentKid = kid;
            _nameText.text = kid.Data.Name;
            _dossierText.text = kid.Data.Dossier;
            _kidPhoto.sprite = kid.Data.Photo;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}