using Application.UseCase.AddContact.Request;
using ContactApp.App.Core.Contact.UseCase.AddContact;
namespace Contact.App.Core.ContactApp.Entity;

public enum ContactAction
{
    Remplacer,
    Coupler,
    Annuler
}

public class AddContactUseCase : IAddContactUseCase
{
    private readonly IContactRepository _contactRepository;

    public AddContactUseCase(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task Execute(AddContactRequest contactRequest, ContactAction action)
    {
        if (contactRequest == null)
            throw new ArgumentNullException(nameof(contactRequest));
        Guid guid = Guid.NewGuid();
        var existingContact = await _contactRepository.GetSingleContactAsync(guid);

        if (existingContact != null)
        {
            switch (action)
            {
                case ContactAction.Remplacer:
                    existingContact.SetFirstName(contactRequest.FirstName);
                    existingContact.SetLastName(contactRequest.LastName);
                    existingContact.SetPhoneNumber(contactRequest.PhoneNumber);
                    await _contactRepository.UpdateContactAsync(existingContact); 
                    break;

                case ContactAction.Coupler:
                    existingContact.SetAdditionalPhoneNumber(contactRequest.PhoneNumber);
                    await _contactRepository.UpdateContactAsync(existingContact); 
                    break;
                    
                case ContactAction.Annuler:
                    return;

                default:
                    throw new ArgumentException("Action non valide", nameof(action));
            }
        }
        else
        {
            var contact = Contact.CreateContact(
                contactRequest.FirstName,
                contactRequest.LastName,
                contactRequest.PhoneNumber,
                contactRequest.Email
            );

            await _contactRepository.AddContactAsync(contact);
        }
    }
}
