using Application.Interfaces;
using Contact.App.Core.Contact.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Delete
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task DeleteContactUseCaseAsync(string email)
        {
            await _contactRepository.DeleteContactAsync(email);
        }
    }
}
