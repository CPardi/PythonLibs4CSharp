namespace Pygments
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using IronPython.Runtime;

    public class Lexer : DynamicWrapper
    {
        public Lexer(dynamic lexer)
        {
            this.Dynamic = lexer;
        }

        /// <summary>
        ///     A list of short, unique identifiers that can be used to lookup the lexer from a list, e.g. using
        ///     <see cref="Pygments.Lexers.GetLexerByName(string, ILexerOptions)"/>.
        /// </summary>
        public ReadOnlyCollection<string> Aliases => ((List)this.Dynamic.aliases).Cast<string>().ToList().AsReadOnly();

        /// <summary>
        ///     A list of fnmatch patterns that match filenames which may or may not contain content for this lexer. This list is
        ///     used by the guess_lexer_for_filename() function, to determine which lexers are then included in guessing the
        ///     correct one. That means that e.g. every lexer for HTML and a template language should include \*.html in this list.
        /// </summary>
        public ReadOnlyCollection<string> AliasFilenames => ((List)this.Dynamic.alias_filenames).Cast<string>().ToList().AsReadOnly();

        /// <summary>
        ///     A list of fnmatch patterns that match filenames which contain content for this lexer. The patterns in this list
        ///     should be unique among all lexers.
        /// </summary>
        public ReadOnlyCollection<string> Filenames => ((List)this.Dynamic.filenames).Cast<string>().ToList().AsReadOnly();

        /// <summary>
        ///     A list of MIME types for content that can be lexed with this lexer.
        /// </summary>
        public ReadOnlyCollection<string> MimeTypes => ((List)this.Dynamic.mimetypes).Cast<string>().ToList().AsReadOnly();

        /// <summary>
        ///     Full name for the lexer, in human-readable form.
        /// </summary>
        public string Name => this.Dynamic.name;
    }
}