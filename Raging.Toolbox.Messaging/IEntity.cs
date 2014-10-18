namespace Truphone.Common.DomainDrivenDesign
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }
    }
}