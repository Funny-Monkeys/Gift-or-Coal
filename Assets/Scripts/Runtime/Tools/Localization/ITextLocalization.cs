using GiftOrCoal.Dossier;

namespace GiftOrCoal.Tools
{
    public interface ITextLocalization
    {
        string Localize(LocalizationText text, string currentText);
    }
}