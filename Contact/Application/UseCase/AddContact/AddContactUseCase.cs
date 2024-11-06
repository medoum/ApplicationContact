using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;

namespace Application.UseCase.AddContact
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IAddContactRepository _addContactRepository;

        public AddContactUseCase(IAddContactRepository addContactRepository)
        {
            _addContactRepository = addContactRepository;
        }

        public async Task ExecuteAsync(Contact contact)
        {
            await _addContactRepository.AddContactAsync(contact);
        }
    }
}
