using System;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;

namespace Contact.App.Core.ContactApp.UseCase.MergeContact
{
    public class MergeContactUseCase 
    {
        private readonly IContactRepository _contactRepository;
        public MergeContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Execute(MergeContactRequest request)
        {
            if (string.IsNullOrEmpty(request.PhoneNumber))
                throw new ArgumentNullException(nameof(request.PhoneNumber));

            var existingContact = await _contactRepository.GetSingleContactAsync(request.contactId);
            if (existingContact == null)
                throw new InvalidOperationException($"Contact avec ID {request.contactId} non trouvé");

            existingContact.SetAdditionalPhoneNumber(request.PhoneNumber);
            await _contactRepository.UpdateContactAsync(existingContact);
        }
    }
}
