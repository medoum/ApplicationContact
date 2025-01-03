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

        public Task DeleteContactAsync(string email)
        {
         
            var contact = _contacts.FirstOrDefault(u => u.Email == email);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }

            return Task.CompletedTask;
        }

        public Task<List<ContactDto>> GetContactsAsync()
        {
           return Task.FromResult(_contacts);
        }

        public Task UpdateContactAsync(ContactDto contact)
        {
           
            var existingContact = _contacts.FirstOrDefault(u => u.Email == contact.Email);
            if (existingContact != null)
            {
                // Mise à jour des propriétés de l'utilisateur
                existingContact.FirstName = contact.FirstName;
                existingContact.Email = contact.Email;
                existingContact.LastName = contact.LastName;
                existingContact.PhoneNumber = contact.PhoneNumber;
            }

            return Task.CompletedTask;
        }
    }
}
