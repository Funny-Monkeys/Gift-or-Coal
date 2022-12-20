using UnityEngine;

namespace GiftOrCoal.UI
{
    public sealed class ExitButton : Button
    {
        protected override void OnClick()
        {
            Application.Quit();
        }
    }
}