using Contact.App.Core.Contact.Repository;

namespace Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        public static List<Contact.App.Core.Contact.Entity.Contact> _contacts = [];


        public Task AddContactAsync(Contact.App.Core.Contact.Entity.Contact contact)
        {
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(Guid id)
        {
         
            var contact = _contacts.FirstOrDefault(u => u.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }

            return Task.CompletedTask;
        }

        public Task<List<Contact.App.Core.Contact.Entity.Contact>> GetContactsAsync()
        {
           return Task.FromResult(_contacts);
        }

        public Task<Contact.App.Core.Contact.Entity.Contact> GetSingleContactAsync(Guid id)
        {
            var contact = _contacts.FirstOrDefault(c=> c.Id == id);
            if (contact != null)
            {
                return Task.FromResult(contact);
            }

            return Task.FromResult<Contact.App.Core.Contact.Entity.Contact>(null); 
        }


        public Task UpdateContactAsync(Contact.App.Core.Contact.Entity.Contact contact)
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
