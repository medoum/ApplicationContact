using Contact.App.Core.Contact.Entity;

namespace Contact.App.Core.Contact.Repository
{
    public interface IContactRepository
    {
        Task AddContactAsync(Entity.Contact contact);
        Task <List<Entity.Contact>> GetContactsAsync();

        Task UpdateContactAsync(Entity.Contact contact);

        Task DeleteContactAsync(Guid id);

        public Task<Entity.Contact> GetSingleContactAsync(Guid id);
    }
}
