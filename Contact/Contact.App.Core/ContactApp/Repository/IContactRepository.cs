
namespace Contact.App.Core.ContactApp.Entity;

public interface IContactRepository
{
    Task AddContactAsync(Contact contact);
    Task<List<Contact>> GetContactsAsync();
    Task DeleteContactAsync(Guid id);
    Task<Contact> GetContactByIdAsync(Guid id);
    Task<Contact> GetSingleContactAsync(string email, string phoneNumber);
}
