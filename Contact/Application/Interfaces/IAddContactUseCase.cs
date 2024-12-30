using Application.UseCase.AddContact.Request;

namespace Application.Interfaces
{
    public interface IAddContactUseCase
    {
        Task AddContact(AddContactRequest contactRequest);
    }
}
