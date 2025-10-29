using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.AddContactToGroup;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.MergeContact
{
    public class MergeContactUseCase
    {
        private readonly IContactRepository _contactRepository;
        private readonly AddContactToGroupUseCase _addContactToGroupUseCase;
        public MergeContactUseCase(IContactRepository contactRepository, AddContactToGroupUseCase addContactToGroupUseCase)
        {
            _contactRepository = contactRepository;
            _addContactToGroupUseCase = addContactToGroupUseCase;
        }

        public async Task<Guid> Execute(MergeContactRequest request)
        {
            var existingContact = await _contactRepository.GetSingleContactAsync(request.Email, request.PhoneNumber);

            if (!existingContact.IsValid())
                throw new InvalidOperationException(InvalidError.ContactAlreadyExists);

            // Orchestration dans le modèle
            bool hasChanges = existingContact.MergeWith(
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.Email
            );

                await _contactRepository.UpdateContactAsync(existingContact);
            if (request.GroupId.HasValue)
            {
                await _addContactToGroupUseCase.Execute(request.GroupId.Value, existingContact.GetId());
            }

            return existingContact.GetId();
        }

    }
}