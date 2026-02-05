using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Repository;
using ContactApp.App.Core.Contact.UseCase.AddContact;

namespace Contact.App.Core.ContactApp.Entity
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository _contRepository;

        public AddContactUseCase(IContactRepository contRepository)
        {
            _contRepository = contRepository;
        }

        public async Task<Guid> Execute(AddContactRequest contactRequest)
        {
            var newContact = Contact.Create(
                contactRequest.FirstName,
                contactRequest.LastName,
                contactRequest.PhoneNumber,
                contactRequest.Email,
                contactRequest.GroupId
            );

            await _contRepository.AddAsync(newContact);


            return newContact.GetId();
        }
    }
}