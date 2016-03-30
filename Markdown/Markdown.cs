namespace Markdown
{
    using System.Collections.Generic;
    using System.Reflection;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    using PythonLibs4CSharp;
    using static PythonLibs4CSharp.Utilities;

    public static class Markdown
    {
        private static dynamic _module;

        public static ScriptEngine Engine { get; set; }

        public static void Import(ScriptEngine engine)
        {
            Engine = engine;
            GetAndLoadAssembly(nameof(Markdown) + ".Markdown.dll", engine, Assembly.GetExecutingAssembly());
            _module = engine.ImportModule("markdown");
            Extensions.ExtensionsModule = engine.ImportModule("markdown.extensions");
        }

        public static string Transform(string text) => _module.markdown(text);

        public static string Transform(string text, MarkdownOptions options) =>
            (string)Engine.Execute(
                "markdown.markdown(text, **options)",
                Engine.CreateScope(new Dictionary<string, object> { { "markdown", _module }, { "text", text }, { "options", options.ToDictionary() } }));

        internal static dynamic InitializeTranform() => _module.Markdown();

        internal static dynamic InitializeTranform(MarkdownOptions options) =>
            Engine.Execute(
                "markdown.Markdown(**options)",
                Engine.CreateScope(new Dictionary<string, object> { { "markdown", _module }, { "options", options.ToDictionary() } }));

        public static class Extensions
        {
            internal static dynamic ExtensionsModule { get; set; }

            public static Extension GetExtensionByName(string name)
            {
                return new Extension(
                    Engine.Execute(
                        $"extensions.{name}()",
                        Engine.CreateScope(new Dictionary<string, object>() { { "extensions", ExtensionsModule } })));
            }
        }
    }

    public class Extension : DynamicWrapper
    {
        internal Extension(dynamic extension)
        {
            this.Dynamic = extension;
        }
    }
}