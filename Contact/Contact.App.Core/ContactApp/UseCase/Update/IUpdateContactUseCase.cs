

namespace ContactApp.App.Core.Contact.UseCase.Update
{
    public interface IUpdateContactUseCase
    {
        Task UpdateContactUseCaseAsync(Entity.Contact contact);
    }
}
