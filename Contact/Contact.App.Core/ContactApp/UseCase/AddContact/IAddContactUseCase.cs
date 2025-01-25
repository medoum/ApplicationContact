using Application.UseCase.AddContact.Request;

namespace ContactApp.App.Core.Contact.UseCase.AddContact
{
    public interface IAddContactUseCase
    {
        Task Execute(AddContactRequest contactRequest);
    }
}
