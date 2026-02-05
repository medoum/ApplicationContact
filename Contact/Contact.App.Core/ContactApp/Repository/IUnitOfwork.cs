namespace Contact.App.Core.ContactApp.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void RegisterOperation(Action operation);
        Task<int> SaveChangesAsync();
    }


}
