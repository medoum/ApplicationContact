using Contact.App.Core.ContactApp.Entity;

namespace Contact.App.Core.ContactApp.Repository
{
    public interface IContactGroupRepository
    {
        Task<ContactGroup?> GetByIdAsync(Guid id);
        Task<List<ContactGroup>> GetAllAsync();
        Task AddAsync(ContactGroup contactGroup);
        Task UpdateAsync(ContactGroup contactGroup);
        Task DeleteAsync(Guid id);

        Task<ContactGroup?> GetByNameAsync(string name);
    }
}
