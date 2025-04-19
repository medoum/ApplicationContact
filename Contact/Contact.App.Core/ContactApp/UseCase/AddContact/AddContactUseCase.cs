using Application.UseCase.AddContact.Request;
using ContactApp.App.Core.Contact.UseCase.AddContact;
namespace Contact.App.Core.ContactApp.Entity;


public class AddContactUseCase : IAddContactUseCase
{
    private readonly IContactRepository _contactRepository;

    public AddContactUseCase(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<Guid> Execute(AddContactRequest contactRequest)
    {
        // gerer le cas ou le contact existe
        var contact = Contact.CreateContact(
            
            contactRequest.FirstName,
            contactRequest.LastName,
            contactRequest.PhoneNumber,
            contactRequest.Email
        );
        await _contactRepository.AddContactAsync(contact);
        return contact.GetId();
    }
}
