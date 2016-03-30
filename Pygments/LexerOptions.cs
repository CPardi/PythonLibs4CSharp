namespace Pygments
{
    using System.Collections.Generic;
    using PythonLibs4CSharp;

    public class LexerOptions : ILexerOptions
    {
        public LexerOptions(params KeyValuePair<string, object>[] additionalOptions)
        {
            this.AdditionalOptions = additionalOptions;
        }

        public KeyValuePair<string, object>[] AdditionalOptions { get; }

        /// <summary>
        ///     If given, must be an encoding name (such as "utf-8"). This encoding will be used to convert the input string to
        ///     Unicode (if it is not already a Unicode string). The default is "guess".
        /// </summary>
        public string Encoding { get; set; } = null;

        /// <summary>
        ///     Make sure that the input ends with a newline (default: True). This is required for some lexers that consume input
        ///     linewise.
        /// </summary>
        public bool? EnsureEnl { get; set; } = null;

        /// <summary>
        ///     Strip all leading and trailing whitespace from the input (default: False).
        /// </summary>
        public bool? StripAll { get; set; } = null;

        /// <summary>
        ///     Strip leading and trailing newlines from the input (default: True)
        /// </summary>
        public bool? StripNl { get; set; } = null;

        /// <summary>
        ///     If given and greater than 0, expand tabs in the input (default: 0).
        /// </summary>
        public int? TabSize { get; set; } = null;

        public IDictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.AddIfNotNull("encoding", this.Encoding);
            dictionary.AddIfNotNull("ensureenl", this.EnsureEnl);
            dictionary.AddIfNotNull("stripall", this.StripAll);
            dictionary.AddIfNotNull("stripnl", this.StripNl);
            dictionary.AddIfNotNull("tabsize", this.TabSize);

            foreach (var ao in this.AdditionalOptions)
            {
                dictionary.Add(ao.Key, ao.Value);
            }

            return dictionary;
        }
    }
}