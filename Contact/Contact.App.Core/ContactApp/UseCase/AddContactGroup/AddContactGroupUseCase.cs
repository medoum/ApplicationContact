using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;


namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public class AddContactGroupUseCase : IAddContactGroup
    {
     
        private readonly IUnitOfWork _unitOfWork;

        public AddContactGroupUseCase( IUnitOfWork unitOfWork)
        {
          
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Entity.Contact contact,ContactGroup group)
        {
            _unitOfWork.Contacts.AddContactAsync(contact);
            _unitOfWork.ContactGroups.AddAsync(group);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
