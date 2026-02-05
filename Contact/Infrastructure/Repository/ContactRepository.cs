using Contact.App.Core.ContactApp.Repository;

namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        public Task AddAsync(Contact contact)
        {          
                _contacts.Add(contact);
            
            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(Guid id)
        {
             var contact = _contacts.FirstOrDefault(c => c.GetId() == id);
              
          
            return Task.CompletedTask;
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            var contacts = _contacts
                .Where(c => c.IsValid())
                .ToList();

            return Task.FromResult(contacts);
        }

        public Task<Contact?> GetContactByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("L'ID ne peut pas être vide.", nameof(id));

            var contact = _contacts.FirstOrDefault(c =>
                c.GetId() == id && c.IsValid());

            return Task.FromResult(contact);
        }

        public Task<Contact?> GetSingleContactAsync(string email, string phoneNumber)
        {
           
            var contact = _contacts.FirstOrDefault(c =>
                c.IsValid() 
            );

            return Task.FromResult(contact);
        }

        public Task UpdateContactAsync(Contact existingContact)
        {
          
                var index = _contacts.FindIndex(c =>
                    c.GetId() == existingContact.GetId());

                if (index == -1)
                    throw new InvalidOperationException(
                        $"Le contact avec l'ID {existingContact.GetId()} n'existe pas."
                    );

                _contacts[index] = existingContact;
      

            return Task.CompletedTask;
        }
    }
}
