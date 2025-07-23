namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactRepository : IContactRepository
    {
        public static List<Contact> _contacts = [];
        public Task AddContactAsync(Contact contact)
        {
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(Guid id)
        {

            var contact = _contacts.FirstOrDefault(u =>  u.GetId() ==  id);
            if (contact.IsValid())
            {
                _contacts.Remove(contact);
            }

            return Task.CompletedTask;
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return Task.FromResult(_contacts);
        }

        public Task<Contact> GetContactByIdAsync(Guid id)
        {
            var contact = _contacts.FirstOrDefault(c => c.GetId() == id);

            if (contact.IsValid())
            {
                return Task.FromResult<Contact?>(contact);
            }

            return Task.FromResult<Contact?>(null);


        }

        public Task UpdateContactAsync(Contact contact)
        {

            var existingContact = _contacts.FirstOrDefault(u => u.GetEmail() == contact.GetEmail());
            if (existingContact.IsValid())
            {
                existingContact.SetFirstName(contact.GetFirstName()); 
                existingContact.SetLastName(contact.GetLastName());
                existingContact.SetPhoneNumber(contact.GetPhoneNumber());
                existingContact.SetEmail(contact.GetEmail());
            }

            return Task.CompletedTask;
        }

        public Task<Contact> GetSingleContactAsync(string email, string phoneNumber)
        {
            var contact = _contacts.FirstOrDefault(c =>
              (c.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase) ||
               c.GetPhoneNumber().Equals(phoneNumber, StringComparison.OrdinalIgnoreCase)) &&
              c.IsValid()
          );

            return Task.FromResult<Contact?>(contact);
        }
    }
}
