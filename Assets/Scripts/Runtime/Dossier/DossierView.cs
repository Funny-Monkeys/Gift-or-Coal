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

        [Space] [SerializeField] private Button _coalButton;
        [SerializeField] private Button _giftButton;
        [SerializeField] private Score.Score _score;

        private Kid _currentKid;

        public void Display(Kid kid)
        {
            _currentKid = kid;
            
            _nameText.text = kid.Data.Name;
            _dossierText.text = kid.Data.Dossier;
            _kidPhoto.sprite = kid.Data.Photo;
        }

        private void CoalButtonCallback()
        {
            if (_currentKid.Deeds.Any(deed => !deed.IsGood)) _score.Add(100);
            else if (_score.CanRemove(100)) _score.Remove(100);
        }

        private void GiftButtonCallback()
        {
            if (_currentKid.Deeds.All(deed => deed.IsGood)) _score.Add(100);
            else if (_score.CanRemove(100)) _score.Remove(100);
        }

        private void Awake()
        {
            _coalButton.onClick.AddListener(CoalButtonCallback);
            _giftButton.onClick.AddListener(GiftButtonCallback);
        }
    }
}