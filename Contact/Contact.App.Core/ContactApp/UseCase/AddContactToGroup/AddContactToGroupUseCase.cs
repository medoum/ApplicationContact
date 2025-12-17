using Contact.App.Core.ContactApp.Repository;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.AddContactToGroup
{
    public class AddContactToGroupUseCase
    {
        private readonly IContactGRoupRepository _contactGroupRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddContactToGroupUseCase(
            IContactGRoupRepository contactGRoupRepository,
            IContactRepository contactRepository,
            IUnitOfWork unitOfWork)
        {
            _contactGroupRepository = contactGRoupRepository;
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid groupId, Guid contactId)
        {
            var group = await _contactGroupRepository.GetByIdAsync(groupId);
            if (group == null)
            {
                throw new InvalidOperationException(InvalidError.GroupNotFound);
            }

            var contact = await _contactRepository.GetContactByIdAsync(contactId);
            if (contact == null || !contact.IsValid())
            {
                throw new InvalidOperationException(InvalidError.ContactNotFound);
            }

            group.AddContact();
            await _contactGroupRepository.UpdateAsync(group);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}