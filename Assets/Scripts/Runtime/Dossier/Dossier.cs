using UnityEngine;

namespace GiftOrCoal.Dossier
{
    public sealed class Dossier : MonoBehaviour
    {
        [field: SerializeField] public DossierView View { get; private set; }
        
        [field: SerializeField] public GiftButton GiftButton { get; private set; }
        
        [field: SerializeField] public CoalButton CoalButton { get; private set; }

    }
}