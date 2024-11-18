using Application.UseCase.AddContact.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(Contact contact);
    }
}
