using Application.UseCase.AddContact.Request;
using ContactApp;
using ContactApp.App.Core.Contact.Entity;
using ContactApp.App.Core.Contact.UseCase.AddContact;
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
            if (contactRequest == null)
                throw new ArgumentNullException(nameof(contactRequest));

            var contact = Contact.CreateContact(
                Guid.NewGuid(),
                contactRequest.FirstName,
                contactRequest.LastName,
                contactRequest.PhoneNumber,
                contactRequest.Email
            );

            await _contactRepository.AddContactAsync(contact);
        }
    }
}

