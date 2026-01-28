using Contact.App.Core.ContactApp.Repository;

namespace Contact.App.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Repositories InMemory
        private readonly IContactGroupRepository _contactGroupRepository;
        private readonly IContactRepository _contactRepository;

        public UnitOfWork(
            IContactGroupRepository contactGroupRepository,
            IContactRepository contactRepository)
        {
            _contactGroupRepository = contactGroupRepository;
            _contactRepository = contactRepository;
        }

        public IContactGroupRepository ContactGroups => _contactGroupRepository;
        public IContactRepository Contacts => _contactRepository;

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return Task.CompletedTask;
        }
    }
}
