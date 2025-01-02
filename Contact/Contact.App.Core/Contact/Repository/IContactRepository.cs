using Contact.App.Core.Contact.Entities;

namespace Contact.App.Core.Contact.Repository
{
    public interface IContactRepository
    {
        Task AddContactAsync(ContactDto contact);
        Task <List<ContactDto>> GetContactsAsync();
    }
}
