using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(Contact contact);
    }
}
