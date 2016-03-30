namespace TestApplication
{
    using System;
    using System.Collections.Generic;
    using Markdown;
    using Pygments;
    using PythonLibs4CSharp;

    public static class Program
    {
        private static void Main()
        {
            var engine = Utilities.CreateEngine();

            StdLib.Import(engine);

            Pygments.Import(engine);
            Markdown.Import(engine);

            var md = new Transform(new MarkdownOptions
            {
                ExtensionPaths = new[]
                {
                    "markdown.extensions.abbr",
                    "markdown.extensions.attr_list",
                    "markdown.extensions.admonition",
                    "markdown.extensions.codehilite",
                    "markdown.extensions.def_list",
                    "markdown.extensions.fenced_code",
                    "markdown.extensions.footnotes",
                    "markdown.extensions.headerid",
                    "markdown.extensions.meta",
                    "markdown.extensions.nl2br",
                    "markdown.extensions.sane_lists",
                    "markdown.extensions.smart_strong",
                    "markdown.extensions.smarty",
                    "markdown.extensions.tables",
                    "markdown.extensions.tables",
                    "markdown.extensions.toc",
                    "markdown.extensions.wikilinks",
                },
                ExtensionConfigs = new Dictionary<string, Dictionary<string, string>>()
                {
                    {
                        "markdown.extensions.codehilite",
                        new Dictionary<string, string>()
                        {
                            { "linenums", "True" },
                            { "noclasses", "True" }
                        }
                    }
                }
            });

            Console.WriteLine(md.Convert("#Heading 1\n##Heading 2\n\n```fortran\nprogram new\nend program\n```\nPara\n{: #id1 .class1 id=id2 class=\"class2 class3\" .class4 }"));

            //Pygments.Import(engine);
            var lexer = Pygments.Lexers.GetLexerByName("Fortran");

            Console.WriteLine(lexer.Name);

            foreach (var a in lexer.Aliases)
            {
                Console.WriteLine(a);
            }

            //foreach (var a in lexer.Filenames)
            //{
            //    Console.WriteLine(a);
            //}

            //foreach (var a in lexer.AliasFilenames)
            //{
            //    Console.WriteLine(a);
            //}
            //foreach (var a in lexer.MimeTypes)
            //{
            //    Console.WriteLine(a);
            //}

            var formatter = Pygments.Formatters.GetFormatterByName("html");

            Console.WriteLine(formatter.Name);

            foreach (var a in formatter.Aliases)
            {
                Console.WriteLine(a);
            }

            //foreach (var a in formatter.Filenames)
            //{
            //    Console.WriteLine(a);
            //}

            ////var style = Pygments.Styles.GetStyleByName("emacs");

            ////Console.WriteLine(Pygments.Highlight("program hello\ncontains\nsubroutine new()\n end subroutine\nend program", lexer, formatter));

            ////Console.WriteLine(formatter.Name);
            ////Console.WriteLine(formatter.GetStyleDefs());
        }
    }
}