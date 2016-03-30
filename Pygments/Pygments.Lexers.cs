namespace Pygments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IronPython.Runtime;

    public partial class Pygments
    {
        public static class Lexers
        {
            internal static dynamic LexersModule { get; set; }

            /// <summary>
            ///     Return an instance of a Lexer subclass that has alias in its aliases list. The lexer is given the options at its
            ///     instantiation.
            /// </summary>
            /// <param name="name">The alias of the returned lexer.</param>
            /// <returns>A lexer with alias <paramref name="name" />.</returns>
            /// <exception cref="InvalidOperationException">Raised if no lexer with that alias is found.</exception>
            public static Lexer GetLexerByName(string name)
            {
                try
                {
                    return new Lexer(LexersModule.get_lexer_by_name(name));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
            }

            /// <summary>
            ///     Return an instance of a Lexer subclass that has alias in its aliases list. The lexer is given the options at its
            ///     instantiation.
            /// </summary>
            /// <param name="name">The alias of the returned lexer.</param>
            /// <param name="options">Options to pass to the lexer on initialization.</param>
            /// <returns>A lexer with alias <paramref name="name" />.</returns>
            /// <exception cref="InvalidOperationException">Raised if no lexer with that alias is found.</exception>
            public static Lexer GetLexerByName(string name, ILexerOptions options)
            {
                try
                {
                    return new Lexer(Engine.Execute(
                        "lexers.get_lexer_by_name(name, **options)",
                        Engine.CreateScope(new Dictionary<string, object> { { "name", name }, { "lexers", LexersModule }, { "options", options?.ToDictionary() } })));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
            }
        }
    }
}