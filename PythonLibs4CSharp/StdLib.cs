namespace PythonLibs4CSharp
{
    using System.Reflection;
    using Microsoft.Scripting.Hosting;

    public static class StdLib
    {
        public static void Import(ScriptEngine engine)
            => Utilities.GetAndLoadAssembly(nameof(PythonLibs4CSharp) + ".StdLib.dll", engine, Assembly.GetExecutingAssembly());
    }
}