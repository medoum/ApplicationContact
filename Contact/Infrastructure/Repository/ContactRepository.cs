using Contact.App.Core.Contact.Entities;
using Contact.App.Core.Contact.Repository;

namespace Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactDto> _contacts = [];


        public Task AddContactAsync(ContactDto contact)
        {
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task<List<ContactDto>> GetContactsAsync()
        {
           return Task.FromResult(_contacts);
        }
    }
}
