using Application.UseCase.AddContact.Request;
using ContactApp.App.Core.Contact.UseCase.AddContact;
using ContactApp.App.Core.shared.Exceptions;
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
        var existingContact = await _contactRepository.GetSingleContactAsync(contactRequest.ContactId);

        if(existingContact != null)
        {
            throw new InvalidOperationException(InvalidError.ContactAlreadyExists);
        }
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
