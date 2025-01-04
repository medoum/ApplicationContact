using Contact.App.Core.Contact.Entities;

namespace Contact.App.Core.Contact.Repository
{
    public interface IContactRepository
    {
        Task AddContactAsync(Entities.Contact contact);
        Task <List<Entities.Contact>> GetContactsAsync();

        Task UpdateContactAsync(Entities.Contact contact);

        Task DeleteContactAsync(string email);
    }
}
