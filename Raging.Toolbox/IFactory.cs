namespace Raging.Toolbox
{
    public interface IFactory<out T> where T : class
    {
        T Create();
    }

    public interface IFactory<out T, in TArgument> where T : class
    {
        T Create(TArgument args);
    }

    public interface IFactory<out T, in TArgument1, in TArgument2> where T : class
    {
        T Create(TArgument1 argument1, TArgument2 argument2);
    }

    public interface IFactory<out T, in TArgument1, in TArgument2, in TArgument3> where T : class
    {
        T Create(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3);
    }

    public interface IFactory<out T, in TArgument1, in TArgument2, in TArgument3, in TArgument4> where T : class
    {
        T Create(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4);
    }

    public interface IFactory<out T, in TArgument1, in TArgument2, in TArgument3, in TArgument4, in TArgument5> where T : class
    {
        T Create(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5);
    }

    public interface IFactory<out T, in TArgument1, in TArgument2, in TArgument3, in TArgument4, in TArgument5, in TArgument6> where T : class
    {
        T Create(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3, TArgument4 argument4, TArgument5 argument5, TArgument6 argument6);
    }
}
