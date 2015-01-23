using System;

namespace Raging.Toolbox.Extensions
{
    /// <summary>
    ///     A generic ambient container for any type instance.
    /// </summary>
    public static class System<T> where T : class
    {
        private static AmbientSingleton<T> singleton;

        /// <summary>
        ///     Gets the component instance.
        /// </summary>
        /// <value>The T component.</value>
        public static T Instance
        {
            get { return singleton.Value; }
        }

        public static T Customize(Func<T> factory)
        {
            return (singleton = AmbientSingleton.Create(factory())).Value;
        }
    }
}