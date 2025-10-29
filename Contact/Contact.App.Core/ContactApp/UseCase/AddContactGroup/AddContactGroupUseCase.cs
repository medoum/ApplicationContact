using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;


namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public class AddContactGroupUseCase : IAddContactGroup
    {
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactRepository _contactRepository;

        public AddContactGroupUseCase( IUnitOfWork unitOfWork, IContactRepository contactRepository)
        {
          
            _unitOfWork = unitOfWork;
            _contactRepository = contactRepository; 
        }

        public async Task Execute(Entity.Contact contact, ContactGroup group)
        {
          
            await _contactRepository.AddContactAsync(
                contact.GetFirstName(),
                contact.GetLastName(),
                contact.GetEmail(),
                contact.GetPhoneNumber(),
                group.GetId()
            );


            await _unitOfWork.SaveChangesAsync();
        }
    }
}
