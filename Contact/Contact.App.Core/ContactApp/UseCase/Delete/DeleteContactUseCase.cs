
using Contact.App.Core.ContactApp.UseCase.Delete;

namespace Application.UseCase.Delete
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly Contact.App.Core.ContactApp.Entity.IContactRepository _contactRepository;

        public DeleteContactUseCase(Contact.App.Core.ContactApp.Entity.IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task DeleteContactUseCaseAsync(Guid id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }
    }
}
