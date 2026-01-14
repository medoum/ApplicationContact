using Contact.App.Core.ContactApp.Repository;

namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();
        private readonly IUnitOfWork _unitOfWork;

        public ContactRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task AddContactAsync(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (!contact.IsValid())
                throw new InvalidOperationException("Le contact n'est pas valide.");

            if (_contacts.Any(c => c.GetId() == contact.GetId()))
                throw new InvalidOperationException(
                    $"Un contact avec l'ID {contact.GetId()} existe déjà."
                );

            _unitOfWork.RegisterOperation(() =>
            {
                _contacts.Add(contact);
            });

            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("L'ID ne peut pas être vide.", nameof(id));

            _unitOfWork.RegisterOperation(() =>
            {
                var contact = _contacts.FirstOrDefault(c => c.GetId() == id);
                if (contact != null)
                {
                    _contacts.Remove(contact);
                }
            });

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
            if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Au moins un critère de recherche doit être fourni.");

            var contact = _contacts.FirstOrDefault(c =>
                c.IsValid() &&
                (
                    (!string.IsNullOrWhiteSpace(email) &&
                     c.GetEmail()?.Equals(email, StringComparison.OrdinalIgnoreCase) == true)
                    ||
                    (!string.IsNullOrWhiteSpace(phoneNumber) &&
                     c.GetPhoneNumber()?.Equals(phoneNumber, StringComparison.OrdinalIgnoreCase) == true)
                )
            );

            return Task.FromResult(contact);
        }

        public Task UpdateContactAsync(Contact existingContact)
        {
            if (existingContact == null)
                throw new ArgumentNullException(nameof(existingContact));

            if (!existingContact.IsValid())
                throw new InvalidOperationException("Le contact n'est pas valide.");

            _unitOfWork.RegisterOperation(() =>
            {
                var index = _contacts.FindIndex(c =>
                    c.GetId() == existingContact.GetId());

                if (index == -1)
                    throw new InvalidOperationException(
                        $"Le contact avec l'ID {existingContact.GetId()} n'existe pas."
                    );

                _contacts[index] = existingContact;
            });

            return Task.CompletedTask;
        }
    }
}
