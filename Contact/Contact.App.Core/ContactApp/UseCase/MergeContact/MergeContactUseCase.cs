using System;
using System.Threading.Tasks;
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
            // recuperation par id
            var existingContact = await _contactRepository.GetSingleContactAsync(request.PhoneNumber, request.Email);
           
            // methode is valid par exemple
            // plus expressif
            if (existingContact == null)
                throw new InvalidOperationException(InvalidError.ContactAlreadyExists);

            // Mise à jour des informations du contact si nécessaire
            //Orchestrer dans le model
            if (existingContact.GetFirstName() != request.FirstName || existingContact.GetLastName() != request.LastName)
            {
                existingContact.SetFirstName(request.FirstName);
                existingContact.SetLastName(request.LastName);
            }

            // Ajout du numéro de téléphone si différent
            //request 
            if (!string.IsNullOrEmpty(request.PhoneNumber) && existingContact.GetPhoneNumber() != request.PhoneNumber)
            {
                existingContact.SetAdditionalPhoneNumber(request.PhoneNumber);
            }

            await _contactRepository.UpdateContactAsync(existingContact);
            return existingContact.GetId();
        }
    }
}