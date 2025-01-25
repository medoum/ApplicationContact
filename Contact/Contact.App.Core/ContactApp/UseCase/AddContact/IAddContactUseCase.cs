
using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;

namespace ContactApp.App.Core.Contact.UseCase.AddContact
{
    public interface IAddContactUseCase
    {
        Task Execute(AddContactRequest contactRequest, ContactAction action);
    }
}
