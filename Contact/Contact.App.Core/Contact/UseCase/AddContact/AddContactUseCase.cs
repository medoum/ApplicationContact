using Application.UseCase.AddContact.Request;
using Contact.App.Core.Contact.Repository;
using Contact.App.Core.Contact.UseCase.AddContact;
namespace Application.UseCase.AddContact
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public AddContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Execute(AddContactRequest contactRequest)
        {
            Contact.App.Core.Contact.Entity.Contact contact = ContactFactory.CreateContact(contactRequest.FirstName, contactRequest.LastName, contactRequest.PhoneNumber, contactRequest.Email);
            await _contactRepository.AddContactAsync(contact);
        }
    }
}

