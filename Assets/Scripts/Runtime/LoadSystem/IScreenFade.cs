using System;

namespace GiftOrCoal.LoadSystem
{
    public interface IScreenFade
    {
        event Action OnDarkened;

        void FadeIn();

        void FadeOut();
    }
}