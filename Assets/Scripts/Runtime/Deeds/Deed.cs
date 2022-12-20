namespace GiftOrCoal.Deeds
{
    public class Deed
    {
        public readonly string Text;
        public readonly bool IsGood;

        public Deed(string text, bool isGood)
        {
            Text = text;
            IsGood = isGood;
        }
    }
}