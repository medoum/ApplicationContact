
namespace Contact.App.Core.ContactApp.Repository;

public interface IContactRepository
{
    Task AddContactAsync(Entity.Contact contact);
    Task<List<Entity.Contact>> GetContactsAsync();
    Task DeleteContactAsync(Guid id);
    Task<Entity.Contact> GetContactByIdAsync(Guid id);
    Task<Entity.Contact> GetSingleContactAsync(string email, string phoneNumber);
    Task UpdateContactAsync(Entity.Contact existingContact);
}
