namespace Pygments
{
    using System.Collections.Generic;

    public interface IFormatterOptions
    {
        IDictionary<string, object> ToDictionary();
    }
}