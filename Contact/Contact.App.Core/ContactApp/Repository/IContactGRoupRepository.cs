using Contact.App.Core.ContactApp.Entity;

namespace Contact.App.Core.ContactApp.Repository
{
    public interface IContactGRoupRepository
    {
        Task<ContactGroup> GetByIdAsync(Guid id);
        Task<List<ContactGroup>> GetAllAsync();

        Task AddAsync(ContactGroup contactGroup);

        Task DeleteAsync(Guid id);
        Task UpdateAsync(ContactGroup contactGroup);

        Task<ContactGroup> GetSingleContact(string Name);

    }
}
