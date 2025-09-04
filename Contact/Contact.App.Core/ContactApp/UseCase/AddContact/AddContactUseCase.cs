using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.AddContactToGroup;
using ContactApp.App.Core.Contact.UseCase.AddContact;
using ContactApp.App.Core.Shared.Exceptions;
namespace Contact.App.Core.ContactApp.Entity;


public class AddContactUseCase : IAddContactUseCase
{
    private readonly IContactRepository _contactRepository;
    private readonly AddContactToGroupUseCase _addContactToGroupUseCase;

    public AddContactUseCase(IContactRepository contactRepository, AddContactToGroupUseCase addContactToGroupUseCase)
    {
        _contactRepository = contactRepository;
        _addContactToGroupUseCase = addContactToGroupUseCase;
    }

    public async Task<Guid> Execute(AddContactRequest contactRequest)
    {
        var existingContact = await _contactRepository.GetSingleContactAsync(contactRequest.Email, contactRequest.PhoneNumber);

        if (existingContact != null && existingContact.IsValid())
        {
            throw new InvalidOperationException(InvalidError.ContactAlreadyExists);
        }
        var contact = Contact.CreateContact(
            
            contactRequest.FirstName,
            contactRequest.LastName,
            contactRequest.PhoneNumber,
            contactRequest.Email,
            contactRequest.GroupId

        );
        await _contactRepository.AddContactAsync(contact);

        if (contactRequest.GroupId.HasValue) 
        {
            await _addContactToGroupUseCase.Execute(contactRequest.GroupId.Value, contact.GetId());
        }

          return contact.GetId();
    }
}
