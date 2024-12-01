using Application.UseCase.AddContact.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAddContactUseCase
    {
        Task AddContact(AddContactRequest contactRequest);
    }
}
