namespace Contact.App.Core.ContactApp.Repository
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }

}
