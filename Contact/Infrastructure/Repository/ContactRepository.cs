using Contact.App.Core.Contact.Repository;
using Domain.Entities;

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
    }
}
