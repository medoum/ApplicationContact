using Contact.App.Core.ContactApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Core.ContactApp.UseCase.GetSingleContact
{
    public class GetSingleContact : IGetSingleContact
    {
        private readonly IContactRepository _contactRepository;

        public GetSingleContact(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public Task<Entity.Contact> GetContact(Guid contactId)
        {
            return _contactRepository.GetContactByIdAsync(contactId);
        }
    }
}
