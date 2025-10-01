using Application.UseCase.AddContact.Request;
using Contact.App.Core.shared;
using ContactApp.App.Core.Contact.UseCase.AddContact;

namespace Contact.App.Core.ContactApp.Entity
{


    public class AddContactUseCase : IAddContactUseCase
    {
  
        private readonly IUnitOfWork _unitOfWork;

        public AddContactUseCase(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Execute(AddContactRequest contactRequest)
        {
            await _unitOfWork. .Contacts.AddContactAsync(contact);
        }
    
    }
}
