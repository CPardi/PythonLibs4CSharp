namespace Pygments
{
    using System.Collections.Generic;

    public interface ILexerOptions
    {
        IDictionary<string, object> ToDictionary();
    }
}