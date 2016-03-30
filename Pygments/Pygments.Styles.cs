using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pygments
{
    public partial class Pygments
    {
        public static class Styles
        {
            internal static dynamic StylesModule { get; set; }

            /// <summary>
            /// Return a style class by its short name. The names of the builtin styles are listed in pygments.styles.STYLE_MAP.
            /// </summary>
            /// <param name="name">The short name of the returned style.</param>
            /// <returns>A style with short name <paramref name="name" />.</returns>
            /// <exception cref="InvalidOperationException">Raised if no style with that alias is found.</exception>
            public static Style GetStyleByName(string name)
            {
                try
                {
                    return new Style(StylesModule.get_style_by_name(name));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message, e);
                }
            }

            /// <summary>
            /// Return an enumeration over all registered style names.
            /// </summary>
            /// <returns></returns>
            public static IEnumerable<string> GetAllStyles() => ((IronPython.Runtime.PythonGenerator)StylesModule.get_all_styles()).Cast<string>();
        }
    }
}
