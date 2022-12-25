using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace GiftOrCoal.Dossier
{
    public sealed class LocalizationText : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text Text { get; private set; }
        
        [field: SerializeField] public LocalizeStringEvent LocalizeStringEvent { get; private set; }

        
    }
}