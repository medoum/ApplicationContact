using Contact.App.Core.Contact.Entities;
using Contact.App.Core.Contact.Repository;
using Contact.App.Core.Contact.UseCase.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Update
{
    public class UpdateContactUseCase : IUpdateContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task UpdateContactUseCaseAsync(Contact.App.Core.Contact.Entities.Contact contact)
        {
            await _contactRepository.UpdateContactAsync(contact);
        }
    }
}
