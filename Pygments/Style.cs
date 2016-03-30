namespace Pygments
{
    public class Style : DynamicWrapper
    {
        public Style(dynamic style)
        {
            this.Dynamic = style;
        }

        public string Name => this.Dynamic[0];
    }
}