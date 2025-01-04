using Contact.App.Core.Contact.Entities;
using Contact.App.Core.Contact.Repository;

namespace Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        public static List<Contact.App.Core.Contact.Entities.Contact> _contacts = [];


        public Task AddContactAsync(Contact.App.Core.Contact.Entities.Contact contact)
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

        public Task<List<Contact.App.Core.Contact.Entities.Contact>> GetContactsAsync()
        {
           return Task.FromResult(_contacts);
        }

        public Task UpdateContactAsync(Contact.App.Core.Contact.Entities.Contact contact)
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
