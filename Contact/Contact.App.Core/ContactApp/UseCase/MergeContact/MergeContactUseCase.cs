using System;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.MergeContact
{
    public class MergeContactUseCase 
    {
        private readonly IContactRepository _contactRepository;
        public MergeContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Guid> Execute(MergeContactRequest request)
        {

            var existingContact = await _contactRepository.GetSingleContactAsync(request.PhoneNumber, request.Email);
            if (existingContact == null)
                throw new InvalidOperationException(InvalidError.ContactAlreadyExists);

            existingContact.SetAdditionalPhoneNumber(request.PhoneNumber);
            await _contactRepository.UpdateContactAsync(existingContact);
            return existingContact.GetId();
        }
    }
}
