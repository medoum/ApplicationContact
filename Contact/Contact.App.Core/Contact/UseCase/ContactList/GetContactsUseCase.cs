using Contact.App.Core.Contact.Repository;
using Contact.App.Core.Contact.UseCase.ContactList;

namespace Application.UseCase.ContactList
{
    public class GetContactsUseCase : IGetContactsListUsesCase
    {
        private readonly IContactRepository _repository;

        public GetContactsUseCase(IContactRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Contact.App.Core.Contact.Entity.Contact>> GetUserAsync()
        {
            return await _repository.GetContactsAsync();
        }
    }
}
