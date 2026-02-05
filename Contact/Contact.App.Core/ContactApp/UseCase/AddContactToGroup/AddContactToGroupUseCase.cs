using Contact.App.Core.ContactApp.Repository;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.AddContactToGroup
{
    public class AddContactToGroupUseCase
    {
        private readonly IContactGroupRepository _contactGroupRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddContactToGroupUseCase(
            IContactGroupRepository contactGroupRepository,
            IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactGroupRepository = contactGroupRepository;
            _contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(Guid groupId, Guid contactId)
        {
            var group = _contactGroupRepository.GetById(groupId)
                ?? throw new InvalidOperationException(InvalidError.GroupNotFound);

            var contact = await _contactRepository.GetContactByIdAsync(contactId)
                ?? throw new InvalidOperationException(InvalidError.ContactNotFound);

            _unitOfWork.RegisterOperation(() =>
            {
                group.IncrementContacts();
                _contactGroupRepository.Update(group);
            });

            await _unitOfWork.SaveChangesAsync();
        }

    }
}
