using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;
using ContactApp.App.Core.Shared.Exceptions;

namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public class AddContactGroupUseCase : IAddContactGroup
    {
        private readonly IContactGRoupRepository _repository;

        public AddContactGroupUseCase(IContactGRoupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Execute(AddContactGroupRequest request)
        {
            var existingGroup = await _repository.GetSingleContact(request.Name);
            if (existingGroup != null) 
            {
                throw new InvalidOperationException(InvalidError.GroupAlreadyExists);
            }
            var group = ContactGroup.createGroupeContact(
               request.Name
             
            );
            
            await _repository.AddAsync(group);
            return group.GetId();
        }
    }
}
