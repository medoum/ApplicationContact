using Contact.App.Core.Contact.Repository;
using Contact.App.Core.Contact.UseCase.Delete;
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
