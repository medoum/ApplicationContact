using Contact.App.Core.ContactApp.Repository;

public class AddContactToGroupUseCase
{
    private readonly IContactRepository _contactRepository;
    private readonly IContactGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddContactToGroupUseCase(
        IContactRepository contactRepository,
        IContactGroupRepository groupRepository,
        IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid contactId, Guid groupId)
    {
        //var contact = await _contactRepository.GetById(contactId);

        var group = await _groupRepository.GetById(groupId);

        var added = contact.AddToGroup(groupId);

        if (!added)
            return; 

        group.IncrementContacts();

        await _contactRepository.Update(contact);
        await _groupRepository.Update(group);

        await _unitOfWork.CommitAsync();
    }
}
