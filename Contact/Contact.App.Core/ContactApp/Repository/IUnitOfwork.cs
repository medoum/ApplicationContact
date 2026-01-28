namespace Contact.App.Core.ContactApp.Repository
{
    public interface IUnitOfWork
    {
        IContactGroupRepository ContactGroups { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }


}
