namespace Pygments
{
    using System.Reflection;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    using static PythonLibs4CSharp.Utilities;

    public static partial class Pygments
    {
        private static dynamic _module;

        private static ScriptEngine Engine { get; set; }

        /// <summary>
        ///     This is the most high-level highlighting function. It combines lex and format in one function.
        /// </summary>
        /// <param name="code">The source code to be highlighted.</param>
        /// <param name="lexer">The lexer instance to use to tokenize the code.</param>
        /// <param name="formatter">The formmatter instance used to output the result.</param>
        /// <returns>The syntax highlighted code.</returns>
        public static string Highlight(string code, Lexer lexer, Formatter formatter) => _module.highlight(code, lexer.ToDynamic(), formatter.ToDynamic());

        /// <summary>
        ///     Imports the pygments module into the Python engine.
        /// </summary>
        /// <param name="engine">The python engine Pygments should be imported within.</param>
        public static void Import(ScriptEngine engine)
        {
            Engine = engine;
            GetAndLoadAssembly(nameof(Pygments) + ".Pygments.dll", engine, Assembly.GetExecutingAssembly());

            _module = engine.ImportModule("pygments");
            Lexers.LexersModule = ((dynamic)engine.ImportModule("pygments.lexers")).lexers;
            Formatters.FormattersModule = ((dynamic)engine.ImportModule("pygments.formatters")).formatters;
            Styles.StylesModule = ((dynamic)engine.ImportModule("pygments.styles")).styles;
        }
    }
}