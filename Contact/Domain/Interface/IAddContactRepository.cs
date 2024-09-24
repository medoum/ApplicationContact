using Domain.Entities;

namespace Domain.Interface
{
    public interface IAddContactRepository
    {
        Task AddContactAsync(Contact contact);
    }
}
