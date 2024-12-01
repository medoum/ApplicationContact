using Application.Interfaces;
using Application.UseCase.AddContact.Request;
using Domain.Entities;
using Domain.Interface;

namespace Application.UseCase.AddContact
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public AddContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddContact(AddContactRequest contactRequest)
        {
            Contact contact = ContactFactory.CreateContact(contactRequest.FirstName,contactRequest.LastName,contactRequest.PhoneNumber,contactRequest.Email);
            await _contactRepository.AddContactAsync(contact);
        }
    }
}

