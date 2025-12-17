using Contact.App.Core.ContactApp.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactRepository : IContactRepository
    {
        private static readonly List<Contact> _contacts = new();
        private readonly UnitOfWork _unitOfWork;

        public ContactRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task AddContactAsync(Contact contact)
        {
             _unitOfWork.RegisterOperation(() =>
            {
                _contacts.Add(contact);
            });
           
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null && contact.IsValid())
            {
                _context.Contacts.Remove(contact);
            }
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> GetSingleContactAsync(string email, string phoneNumber)
        {
            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c =>
                    (c.GetEmail().ToLower() == email.ToLower() ||
                     c.GetPhoneNumber().ToLower() == phoneNumber.ToLower()) &&
                    c.IsValid()
                );

            return contact;
        }

        public Task UpdateContactAsync(Contact existingContact)
        {
            _context.Contacts.Update(existingContact);
            return Task.CompletedTask;
        }
    }
}