using System;

namespace Raging.Toolbox.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this Object source)
        {
            return null == source;
        }

        public static bool IsNotNull(this Object source)
        {
            return !IsNull(source);
        }
    }
}