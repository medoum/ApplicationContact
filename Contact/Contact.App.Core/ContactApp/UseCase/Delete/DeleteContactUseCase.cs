
using Contact.App.Core.ContactApp.Repository;
using Contact.App.Core.ContactApp.UseCase.Delete;

namespace Application.UseCase.Delete
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task DeleteContactUseCaseAsync(Guid id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }
    }
}
