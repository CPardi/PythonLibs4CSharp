namespace PythonLibs4CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;

    public static class Utilities
    {
        public static ScriptEngine CreateEngine() => Python.CreateEngine();

        public static void GetAndLoadAssembly(string resourseName, ScriptEngine engine, Assembly currentAssembly)
        {
            using (var stream = currentAssembly.GetManifestResourceStream(resourseName))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Count not find the resource '{resourseName}' within '{currentAssembly.FullName}'.");
                }

                var assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                var assembly = Assembly.Load(assemblyData);
                engine.Runtime.LoadAssembly(assembly);
            }
        }

        public static void AddIfNotNull(this IDictionary<string, object> dictionary, string key, object value)
        {
            if (value != null)
            {
                dictionary.Add(key, value);
            }
        }
    }
}