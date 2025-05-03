using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.ReplaceContact
{
    public class ReplaceContactUseCase 
    {
        private readonly IContactRepository _contactRepository;
        public ReplaceContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Execute(ReplaceContactRequest request)
        {

            var existingContact = await _contactRepository.GetSingleContactAsync(request.PhoneNumber, request.Email);
            if (existingContact == null)
                throw new InvalidOperationException(InvalidError.ContactAlreadyExists);

            existingContact.SetFirstName(request.FirstName);
            existingContact.SetLastName(request.LastName);
            existingContact.SetPhoneNumber(request.PhoneNumber);
            existingContact.SetEmail(request.Email);
            await _contactRepository.UpdateContactAsync(existingContact);
        }
    }
}
