using Contact.App.Core.ContactApp.Repository;

namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactRepository : IContactRepository
    {
        private readonly Dictionary<Guid, Contact> _storage = new();

        public Task<Contact> GetById(Guid id)
        {
            _storage.TryGetValue(id, out var contact);

            return Task.FromResult(contact);
        }

        public Task Add(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (_storage.ContainsKey(contact.Id))
                throw new InvalidOperationException("Contact déjà existant.");

            _storage[contact.Id] = contact;

            return Task.CompletedTask;
        }

        public Task Update(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (!_storage.ContainsKey(contact.Id))
                throw new InvalidOperationException("Contact introuvable.");

            _storage[contact.Id] = contact;

            return Task.CompletedTask;
        }
    }
}
