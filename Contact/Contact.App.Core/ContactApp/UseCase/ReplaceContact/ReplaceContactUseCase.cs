using Contact.App.Core.ContactApp.Repository;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.ReplaceContact
{
    public class ReplaceContactUseCase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReplaceContactUseCase(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(ReplaceContactRequest request)
        {
            var existingContact = await _contactRepository.GetSingleContactAsync(request.Email, request.PhoneNumber);

            if (existingContact == null)
                throw new InvalidOperationException(InvalidError.ContactNotFound);

            bool hasChanges = existingContact.ReplaceWith(
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.Email
            );

            if (hasChanges)
            {
                await _contactRepository.UpdateContactAsync(existingContact);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}