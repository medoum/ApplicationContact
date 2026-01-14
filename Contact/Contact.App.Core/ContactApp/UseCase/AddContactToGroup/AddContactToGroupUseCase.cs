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
            _contactGroupRepository = contactGroupRepository
                ?? throw new ArgumentNullException(nameof(contactGroupRepository));

            _contactRepository = contactRepository
                ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        public async Task Execute(Guid groupId, Guid contactId)
        {
            if (groupId == Guid.Empty)
                throw new ArgumentException("GroupId invalide.", nameof(groupId));

            if (contactId == Guid.Empty)
                throw new ArgumentException("ContactId invalide.", nameof(contactId));

            var group = await _contactGroupRepository.GetByIdAsync(groupId);
            if (group == null)
                throw new InvalidOperationException(InvalidError.GroupNotFound);

            var contact = await _contactRepository.GetContactByIdAsync(contactId);
            if (contact == null || !contact.IsValid())
                throw new InvalidOperationException(InvalidError.ContactNotFound);


            group.IncrementContacts();

            await _contactGroupRepository.UpdateAsync(group);
        }
    }
}
