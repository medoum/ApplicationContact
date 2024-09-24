using Domain.Entities;

namespace Application.UseCase.Interfaces
{
    public interface IAddContactUseCase
    {  
        Task ExecuteAsync(Contact contact);
    }
}
