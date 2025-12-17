using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;

namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public class AddContactGroupUseCase : IAddContactGroup
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactGRoupRepository _contactGroupRepository;

        public AddContactGroupUseCase(IUnitOfWork unitOfWork, IContactGRoupRepository contactGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _contactGroupRepository = contactGroupRepository;
        }

        public async Task<Guid> Execute(AddContactGroupRequest request)
        {
            var newGroup = ContactGroup.createGroupeContact(request.Name);

            await _contactGroupRepository.AddAsync(newGroup);
            await _unitOfWork.SaveChangesAsync();

            return newGroup.GetId();
        }
    }
}