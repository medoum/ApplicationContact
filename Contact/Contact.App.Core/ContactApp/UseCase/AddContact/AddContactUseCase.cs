using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Repository;
using ContactApp.App.Core.Contact.UseCase.AddContact;

namespace Contact.App.Core.ContactApp.Entity
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository _repository;

        public AddContactUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Execute(AddContactRequest contactRequest)
        {
            var newContact = Contact.CreateContact(
                contactRequest.FirstName,
                contactRequest.LastName,
                contactRequest.PhoneNumber,
                contactRequest.Email,
                contactRequest.GroupId
            );

            await _repository.AddContactAsync(newContact);


            return newContact.GetId();
        }
    }
}