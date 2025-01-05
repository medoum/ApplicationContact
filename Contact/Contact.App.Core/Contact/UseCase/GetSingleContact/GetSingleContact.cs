using Contact.App.Core.Contact.Repository;


namespace Contact.App.Core.Contact.UseCase.GetSingleContact
{
    public class GetSingleContact : IGetSingleContact
    {
        private readonly IContactRepository _contactRepository;

        public GetSingleContact(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task GetContact(Guid contactId)
        {
           await _contactRepository.GetSingleContactAsync(contactId);
        }
    }
}
