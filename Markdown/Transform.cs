namespace Markdown
{
    using PythonLibs4CSharp;

    public class Transform : DynamicWrapper
    {
        public Transform()
        {
            this.Dynamic = Markdown.InitializeTranform();
        }

        public Transform(MarkdownOptions options)
        {
            this.Dynamic = Markdown.InitializeTranform(options);
        }

        public string Convert(string text) => this.Dynamic.convert(text);

        public Transform Reset()
        {
            this.Dynamic.reset();
            return this;
        }
    }
}