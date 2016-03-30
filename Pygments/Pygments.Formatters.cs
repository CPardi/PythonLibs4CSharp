namespace Pygments
{
    using System;
    using System.Collections.Generic;

    public partial class Pygments
    {
        public static class Formatters
        {
            internal static dynamic FormattersModule { get; set; }

            /// <summary>
            ///     Return an instance of a <see cref="Formatter" /> subclass that has alias in its aliases list. The formatter is
            ///     given the options at its instantiation.
            /// </summary>
            /// <param name="name">The alias of the returned formatter.</param>
            /// <returns>A formmatter with alias <paramref name="name" />.</returns>
            /// <exception cref="InvalidOperationException">Raised if no formatter with that alias is found.</exception>
            public static Formatter GetFormatterByName(string name)
            {
                try
                {
                    return new Formatter(FormattersModule.get_formatter_by_name(name));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
            }

            /// <summary>
            ///     Return an instance of a <see cref="Formatter" /> subclass that has alias in its aliases list. The formatter is
            ///     given the options at its instantiation.
            /// </summary>
            /// <param name="name">The alias of the returned formatter.</param>
            /// <param name="options">Options to pass to the formatter on initialization.</param>
            /// <returns>A formmatter with alias <paramref name="name" />.</returns>
            /// <exception cref="InvalidOperationException">Raised if no formatter with that alias is found.</exception>
            public static Formatter GetFormatterByName(string name, IFormatterOptions options)
            {
                try
                {
                    return new Formatter(Engine.Execute(
                        "formatters.get_formatter_by_name(name, **options)",
                        Engine.CreateScope(new Dictionary<string, object> { { "name", name }, { "formatters", FormattersModule }, { "options", options?.ToDictionary() } })));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
            }
        }
    }
}