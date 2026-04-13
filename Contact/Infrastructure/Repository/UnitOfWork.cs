using Contact.App.Core.ContactApp.Repository;

namespace Contact.App.Infrastructure.UnitOfWork
{
    using Contact.App.Core.ContactApp.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        private bool _committed;

        public bool IsCommitted => _committed;

        public Task CommitAsync()
        {
        
            _committed = true;

            return Task.CompletedTask;
        }
    }

}
