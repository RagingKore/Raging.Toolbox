namespace Raging.Toolbox.Patterns
{
    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">Generic type parameter.</typeparam>
    public interface IFactory<T> where T : class
    {
        T Create();
    }

    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <typeparam name="TArgs">Type of the arguments.</typeparam>
    public interface IFactory<T,TArgs> where T : class
    {
        T Create(TArgs args);
        T Create(params TArgs[] args);
    }

    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <typeparam name="TArgs1">Type of the arguments 1.</typeparam>
    /// <typeparam name="TArgs2">Type of the arguments 2.</typeparam>
    public interface IFactory<T, TArgs1, TArgs2> where T : class
    {
        T Create(TArgs1 args1, TArgs2 args2);
    }

    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <typeparam name="TArgs1">Type of the arguments 1.</typeparam>
    /// <typeparam name="TArgs2">Type of the arguments 2.</typeparam>
    /// <typeparam name="TArgs3">Type of the arguments 3.</typeparam>
    public interface IFactory<T, TArgs1, TArgs2, TArgs3> where T : class
    {
        T Create(TArgs1 args1, TArgs2 args2, TArgs3 args3);
    }

    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <typeparam name="TArgs1">Type of the arguments 1.</typeparam>
    /// <typeparam name="TArgs2">Type of the arguments 2.</typeparam>
    /// <typeparam name="TArgs3">Type of the arguments 3.</typeparam>
    /// <typeparam name="TArgs4">Type of the arguments 4.</typeparam>
    public interface IFactory<T, TArgs1, TArgs2, TArgs3, TArgs4> where T : class
    {
        T Create(TArgs1 args1, TArgs2 args2, TArgs3 args3, TArgs4 args4);
    }

    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">        Generic type parameter. </typeparam>
    /// <typeparam name="TArgs1">   Type of the arguments 1. </typeparam>
    /// <typeparam name="TArgs2">   Type of the arguments 2. </typeparam>
    /// <typeparam name="TArgs3">   Type of the arguments 3. </typeparam>
    /// <typeparam name="TArgs4">   Type of the arguments 4. </typeparam>
    /// <typeparam name="TArgs5">   Type of the arguments 5. </typeparam>
    public interface IFactory<T, TArgs1, TArgs2, TArgs3, TArgs4, TArgs5> where T : class
    {
        T Create(TArgs1 args1, TArgs2 args2, TArgs3 args3, TArgs4 args4, TArgs5 args5);
    }

    /// <summary>
    /// Interface for creating a factory.
    /// </summary>
    ///
    /// <typeparam name="T">        Generic type parameter. </typeparam>
    /// <typeparam name="TArgs1">   Type of the arguments 1. </typeparam>
    /// <typeparam name="TArgs2">   Type of the arguments 2. </typeparam>
    /// <typeparam name="TArgs3">   Type of the arguments 3. </typeparam>
    /// <typeparam name="TArgs4">   Type of the arguments 4. </typeparam>
    /// <typeparam name="TArgs5">   Type of the arguments 5. </typeparam>
    /// <typeparam name="TArgs6">   Type of the arguments 6. </typeparam>
    public interface IFactory<T, TArgs1, TArgs2, TArgs3, TArgs4, TArgs5, TArgs6> where T : class
    {
        T Create(TArgs1 args1, TArgs2 args2, TArgs3 args3, TArgs4 args4, TArgs5 args5, TArgs6 args6);
    }

}
