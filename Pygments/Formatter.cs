namespace Pygments
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using IronPython.Runtime;

    public class Formatter : DynamicWrapper
    {
        public Formatter(dynamic formatter)
        {
            this.Dynamic = formatter;
        }

        /// <summary>
        ///     A list of fnmatch patterns that match filenames for which this formatter can produce output. The patterns in this
        ///     list should be unique among all formatters.
        /// </summary>
        public ReadOnlyCollection<string> Aliases => ((List)this.Dynamic.aliases).Cast<string>().ToList().AsReadOnly();

        /// <summary>
        ///     A list of short, unique identifiers that can be used to lookup the formatter from a list, e.g. using
        ///     <see cref="Pygments.Formatters.GetFormatterByName(string, IFormatterOptions)" />.
        /// </summary>
        public ReadOnlyCollection<string> Filenames => ((List)this.Dynamic.filenames).Cast<string>().ToList().AsReadOnly();

        /// <summary>
        ///     Full name for the formatter, in human-readable form.
        /// </summary>
        public string Name => this.Dynamic.name;

        /// <summary>
        ///     Returns statements or declarations suitable to define the current style for subsequent highlighted
        ///     text (e.g. CSS classes in the HTMLFormatter).
        /// </summary>
        /// <returns>The style definition for the formmater.</returns>
        public string GetStyleDefs() => this.Dynamic.get_style_defs();

        /// <summary>
        ///     Returns statements or declarations suitable to define the current style for subsequent highlighted
        ///     text (e.g. CSS classes in the HTMLFormatter).
        /// </summary>
        /// <param name="arg">The optional argument arg can be used to modify the generation and is formatter dependent (it is standardized because it can be given on the command line).</param>
        /// <returns>The style definition for the formmater.</returns>
        public string GetStyleDefs(string arg) => this.Dynamic.get_style_defs(arg);
    }
}