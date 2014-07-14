namespace Raging.Toolbox.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object source)
        {
            return null == source;
        }

        public static bool IsNotNull(this object source)
        {
            return null != source;
        }

        public static bool IsNumericType(this object source)
        {
            return source.GetType().IsNumericType();
        }
    }
}