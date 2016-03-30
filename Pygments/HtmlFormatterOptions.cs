namespace Pygments
{
    using System.Collections.Generic;
    using PythonLibs4CSharp;

    /// <summary>
    /// Format tokens as HTML 4 <span> tags within a &lt;pre&gt; tag, wrapped in a &lt;div&gt; tag. The &lt;div&gt;‘s CSS class can be set by the cssclass option.
    /// If the linenos option is set to "table", the &lt;pre&gt; is additionally wrapped inside a&lt;table&gt; which has one row and two cells: one containing the line numbers and one containing the code. 
    /// </summary>
    public class HtmlFormatterOptions : IFormatterOptions
    {
        /// <summary>
        ///     If set to True, will wrap line numbers in &lt;a&gt; tags. Used in combination with linenos and lineanchors.
        /// </summary>
        public bool? AnchorLineNos { get; set; } = null;

        /// <summary>
        ///     Since the token types use relatively short class names, they may clash with some of your own class names. In this
        ///     case you can use the classprefix option to give a string to prepend to all Pygments-generated CSS class names for
        ///     token types. Note that this option also affects the output of get_style_defs().
        /// </summary>
        public string ClassPrefix { get; set; } = null;

        /// <summary>
        ///     CSS class for the wrapping &lt;div&gt; tag (default: 'highlight'). If you set this option, the default selector for
        ///     get_style_defs() will be this
        ///     class.
        /// </summary>
        public string CssClass { get; set; } = null;

        /// <summary>
        ///     If the full option is true and this option is given, it must be the name of an external file. If the filename does
        ///     not include an absolute path, the file’s path will be assumed to be relative to the main output file’s path, if the
        ///     latter can be found. The stylesheet is then written to this file instead of the HTML file.
        /// </summary>
        public string CssFile { get; set; } = null;

        /// <summary>
        ///     Inline CSS styles for the wrapping  &lt;div&gt; tag (default: '').
        /// </summary>
        public string CssStyles { get; set; } = null;

        /// <summary>
        ///     A string used to generate a filename when rendering  &lt;pre&gt; blocks, for example if displaying source code.
        /// </summary>
        public string Filename { get; set; } = null;

        /// <summary>
        ///     Tells the formatter to output a “full” document, i.e. a complete self-contained document (default: False).
        /// </summary>
        public bool? Full { get; set; } = null;

        /// <summary>
        ///     Specify a list of lines to be highlighted.
        /// </summary>
        public List<int> HlLines { get; set; } = null;

        /// <summary>
        ///     If set to a nonempty string, e.g. foo, the formatter will wrap each output line in an anchor tag with a name of
        ///     foo-linenumber. This allows easy linking to certain lines.
        /// </summary>
        public string LineAnchors { get; set; } = null;

        /// <summary>
        ///     If set to 'table', output line numbers as a table with two cells, one containing the line numbers, the other the
        ///     whole code. This is copy-and-paste-friendly, but may cause alignment problems with some browsers or fonts. If set
        ///     to 'inline', the line numbers will be integrated in the &lt;pre&gt; tag that contains the code (that setting is new
        ///     in Pygments 0.8).
        /// </summary>
        public string LineNos { get; set; } = null;

        /// <summary>
        ///     If set to a number n > 1, only every nth line number is printed.
        /// </summary>
        public int? LineNoSpecial { get; set; } = null;

        /// <summary>
        ///     The line number for the first line (default: 1).
        /// </summary>
        public int? LineNoStart { get; set; } = null;

        /// <summary>
        ///     This string is output between lines of code. It defaults to "\n", which is enough to break a line inside
        ///     &lt;pre&gt; tags, but you can e.g. set it to "<br>" to get HTML line breaks.
        /// </summary>
        public string LineSeperator { get; set; } = null;

        /// <summary>
        ///     If set to a nonempty string, e.g. foo, the formatter will wrap each output line in a span tag with an id of
        ///     foo-linenumber. This allows easy access to lines via javascript.
        /// </summary>
        public string LineSpans { get; set; } = null;

        /// <summary>
        ///     If set to True, the formatter won’t output the background color for the wrapping element (this automatically
        ///     defaults to False when there is no wrapping element [eg: no argument for the get_syntax_defs method given])
        ///     (default: False).
        /// </summary>
        public bool? NoBackground { get; set; } = null;

        /// <summary>
        ///     If set to true, token
        ///     <span>
        ///         tags will not use CSS classes, but inline styles. This is not recommended for larger pieces of code since it
        ///         increases output size by quite a bit (default: False).
        /// </summary>
        public bool? NoClasses { get; set; } = null;

        /// <summary>
        ///     If cssfile is given and the specified file exists, the css file will not be overwritten. This allows the use of the
        ///     full option in combination with a user specified css file. Default is False.
        /// </summary>
        public bool? NoClobberCssfile { get; set; } = null;

        /// <summary>
        ///     If set to True, don’t wrap the tokens at all, not even inside a
        ///     &lt;pre&gt; tag. This disables most other options (default: False).
        /// </summary>
        public bool? NoWrap { get; set; } = null;

        /// <summary>
        ///     Inline CSS styles for the  &lt;pre&gt; tag (default: '').
        /// </summary>
        public string PreStyles { get; set; } = null;

        /// <summary>
        ///     The style to use, can be a string or a Style subclass (default: 'default'). This option has no effect if the
        ///     cssfile and noclobber_cssfile option are given and the file specified in cssfile exists.
        /// </summary>
        public Style Style { get; set; } = null;

        /// <summary>
        ///     If set to the path of a ctags file, wrap names in anchor tags that link to their definitions. lineanchors should be
        ///     used, and the tags file should specify line numbers (see the -n option to ctags).
        /// </summary>
        public string TagsFile { get; set; } = null;

        /// <summary>
        ///     A string formatting pattern used to generate links to ctags definitions. Available variables are %(path)s,
        ///     %(fname)s and %(fext)s. Defaults to an empty string, resulting in just #prefix-number links.
        /// </summary>
        public string TagUrlFormat { get; set; } = null;

        /// <summary>
        ///     If full is true, the title that should be used to caption the document (default: '').
        /// </summary>
        public string Title { get; set; } = null;

        public IDictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.AddIfNotNull("anchorlinenos", this.AnchorLineNos);
            dictionary.AddIfNotNull("classprefix", this.ClassPrefix);
            dictionary.AddIfNotNull("cssclass", this.CssClass);
            dictionary.AddIfNotNull("cssfile", this.CssFile);
            dictionary.AddIfNotNull("cssstyles", this.CssStyles);
            dictionary.AddIfNotNull("filename", this.Filename);
            dictionary.AddIfNotNull("full", this.Full);
            dictionary.AddIfNotNull("hllines", this.HlLines);
            dictionary.AddIfNotNull("lineanchors", this.LineAnchors);
            dictionary.AddIfNotNull("linenos", this.LineNos);
            dictionary.AddIfNotNull("linenospecial", this.LineNoSpecial);
            dictionary.AddIfNotNull("linenostart", this.LineNoStart);
            dictionary.AddIfNotNull("lineseperator", this.LineSeperator);
            dictionary.AddIfNotNull("linespans", this.LineSpans);
            dictionary.AddIfNotNull("nobackground", this.NoBackground);
            dictionary.AddIfNotNull("noclasses", this.NoClasses);
            dictionary.AddIfNotNull("noclobber_cssfile", this.NoClobberCssfile);
            dictionary.AddIfNotNull("nowrap", this.NoWrap);
            dictionary.AddIfNotNull("prestyles", this.PreStyles);
            dictionary.AddIfNotNull("style", this.Style);
            dictionary.AddIfNotNull("tagsfile", this.TagsFile);
            dictionary.AddIfNotNull("tagurlformat", this.TagUrlFormat);
            dictionary.AddIfNotNull("title", this.Title);

            return dictionary;
        }
    }
}