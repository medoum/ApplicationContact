

using Contact.App.Core.ContactApp.Entity;

namespace Application.UseCase.ContactList
{
    public class GetContactsUseCase : IGetContactsListUsesCase
    {
        private readonly IContactRepository _repository;

        public GetContactsUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        async Task<List<Contact.App.Core.ContactApp.Entity.Contact>> IGetContactsListUsesCase.GetUserAsync()
        {
            return await _repository.GetContactsAsync();
        }
    }
}
