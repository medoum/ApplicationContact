using Application.UseCase.AddContact.Request;

namespace Contact.App.Core.Contact.UseCase.AddContact
{
    public interface IAddContactUseCase
    {
        Task AddContact(AddContactRequest contactRequest);
    }
}
