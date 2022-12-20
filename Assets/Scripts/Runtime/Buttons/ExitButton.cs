using UnityEngine;

namespace GiftOrCoal.Buttons
{
    public sealed class ExitButton : Button
    {
        protected override void OnClick()
        {
            Application.Quit();
        }
    }
}