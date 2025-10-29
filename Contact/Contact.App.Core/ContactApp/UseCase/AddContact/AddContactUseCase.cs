using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Repository;
using ContactApp.App.Core.Contact.UseCase.AddContact;

namespace Contact.App.Core.ContactApp.Entity
{


    public class AddContactUseCase : IAddContactUseCase
    {
  
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactRepository _repository;

        public AddContactUseCase(IUnitOfWork unitOfWork, IContactRepository repository)
        {
            
            _unitOfWork = unitOfWork;
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
           

            var createdContact = await _repository.GetContactByIdAsync(newContact.GetId());
            await _unitOfWork.SaveChangesAsync();

            return createdContact.GetId();

        }

    }
}
