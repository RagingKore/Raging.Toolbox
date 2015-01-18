using System;
using System.Linq;

namespace Raging.Toolbox
{
    public static class Enum<T>
        where T : struct, IComparable, IFormattable, IConvertible
    {
        private static T[] values;

        static Enum()
        {
            if(!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type!");  
        }

        public static T[] GetValues()
        {
            return values ?? (values = Enum.GetValues(typeof(T)).Cast<T>().ToArray());
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}