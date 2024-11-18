using Domain.Entities;

namespace Domain.Interface
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
    }
}
