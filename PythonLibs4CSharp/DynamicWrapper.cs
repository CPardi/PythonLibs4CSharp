namespace PythonLibs4CSharp
{
    /// <summary>
    ///     Class to store a dynamic Python variable. Extension classes can define methods to expose attributes of the dynamic.
    /// </summary>
    public abstract class DynamicWrapper
    {
        protected dynamic Dynamic { get; set; }

        /// <summary>
        ///     Returns the dynamic representation of the instance.
        /// </summary>
        /// <returns></returns>
        public dynamic ToDynamic()
        {
            return this.Dynamic;
        }
    }
}