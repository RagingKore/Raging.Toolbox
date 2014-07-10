namespace Raging.Toolbox.Patterns
{
    public interface IEntity<T>
    {
        T Id
        {
            get;
        }
    }
}