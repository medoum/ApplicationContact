using Domain.Entities;

namespace Contact.App.Core.Contact.Repository
{
    public interface IContactRepository
    {
        Task AddContactAsync(ContactDto contact);
    }
}
