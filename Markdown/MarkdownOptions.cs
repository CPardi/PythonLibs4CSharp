namespace Markdown
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PythonLibs4CSharp;

    public class MarkdownOptions
    {
        /// <summary>
        ///     Enable the conversion of attributes. Defaults to True, unless safe_mode is enabled, in which case the default is
        ///     False.
        /// </summary>
        public bool? EnableAttributes { get; set; } = null;

        /// <summary>
        ///     A dictionary of configuration settings for extensions.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> ExtensionConfigs { get; set; } = null;

        /// <summary>
        ///     A list of extensions paths. For example "markdown.extensions.extra".
        /// </summary>
        public IEnumerable<string> ExtensionPaths { get; set; } = null;

        /// <summary>
        ///     Ignore number of first item of ordered lists. Default: True
        /// </summary>
        public bool? LazyOl { get; set; } = null;

        /// <summary>
        ///     Format of output.
        ///     Supported formats are:
        ///     * "xhtml1": Outputs XHTML 1.x.Default.
        ///     * "xhtml5": Outputs XHTML style tags of HTML 5
        ///     * "xhtml": Outputs latest supported version of XHTML(currently XHTML 1.1).
        ///     * "html4": Outputs HTML 4
        ///     * "html5": Outputs HTML style tags of HTML 5
        ///     * "html": Outputs latest supported version of HTML(currently HTML 4).
        /// </summary>
        public string OutputFormat { get; set; } = null;

        /// <summary>
        ///     Treat _connected_words_ intelligently Default: True
        /// </summary>
        public bool? SmartEmphasis { get; set; } = null;

        /// <summary>
        ///     Length of tabs in the source. Default: 4
        /// </summary>
        public int? TabLength { get; set; } = null;

        public Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.AddIfNotNull("extensions", this.ExtensionPaths);
            
            if (this.ExtensionConfigs != null)
            {
                dictionary.Add("extension_configs", ExtensionConfigsToDynamic(this.ExtensionConfigs));
            }
            dictionary.AddIfNotNull("output_format", this.OutputFormat);
            dictionary.AddIfNotNull("tab_length", this.TabLength);
            dictionary.AddIfNotNull("enable_attributes", this.EnableAttributes);
            dictionary.AddIfNotNull("smart_emphasis", this.SmartEmphasis);
            dictionary.AddIfNotNull("lazy_ol", this.LazyOl);

            return dictionary;
        }

        private static dynamic ExtensionConfigsToDynamic(Dictionary<string, Dictionary<string, string>> extensionConfigs)
        {
            return Markdown.Engine.Execute(ExtensionConfigsToString(extensionConfigs));
        }

        private static string ExtensionConfigsToString(Dictionary<string, Dictionary<string, string>> extensionConfigs)
        {
            Func<string, string, string> keyValue = (string key, string value) => $"'{key}':{value}";
            Func<string, string, string> keyValueQ = (string key, string value) => $"'{key}':'{value}'";

            return "{" + string.Concat(
                extensionConfigs
                    .Select((k1,i1) => (i1 == 0 ? "" : ",") + keyValue(k1.Key, $"{{{string.Concat(k1.Value.Select((k2, i2) => (i2 == 0 ? "" : ",") + keyValueQ(k2.Key, k2.Value)))}}}"))) + "}";
        }
    }
}