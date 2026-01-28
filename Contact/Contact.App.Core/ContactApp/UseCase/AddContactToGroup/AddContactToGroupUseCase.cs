using Contact.App.Core.ContactApp.Repository;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.AddContactToGroup
{
    public class AddContactToGroupUseCase
    {
        private readonly IContactGroupRepository _contactGroupRepository;
        private readonly IContactRepository _contactRepository;

        public AddContactToGroupUseCase(
            IContactGroupRepository contactGroupRepository,
            IContactRepository contactRepository)
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

            group.AddContact(contact.GetId());

            _contactGroupRepository.Update(group);
        }

    }
}
