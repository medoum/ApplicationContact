using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;

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

            var existingContact = await _contactRepository.GetSingleContactAsync(request.contactId);
            if (existingContact == null)
                throw new InvalidOperationException($"Contact avec ID {request.contactId} non trouvé");

            existingContact.SetFirstName(request.FirstName);
            existingContact.SetLastName(request.LastName);
            existingContact.SetPhoneNumber(request.PhoneNumber);
            await _contactRepository.UpdateContactAsync(existingContact);
        }
    }
}
