namespace Pygments
{
    public abstract class DynamicWrapper
    {
        protected dynamic Dynamic { get; set; }
        
        public dynamic ToDynamic()
        {
            return this.Dynamic;
        }
    }
}