using Contact.App.Core.Contact.Entities;
using Contact.App.Core.Contact.Repository;
using Contact.App.Core.Contact.UseCase.ContactList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.ContactList
{
    public class GetContactsUseCase : IGetContactsListUsesCase
    {
        private readonly IContactRepository _repository;

        public GetContactsUseCase(IContactRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Contact.App.Core.Contact.Entities.Contact>> GetUserAsync()
        {
            return await _repository.GetContactsAsync();
        }
    }
}
