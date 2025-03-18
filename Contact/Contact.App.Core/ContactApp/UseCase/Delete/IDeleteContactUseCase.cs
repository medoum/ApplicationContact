namespace Contact.App.Core.ContactApp.UseCase.Delete
{
    public interface IDeleteContactUseCase
    {
        Task DeleteContactUseCaseAsync(Guid Id);
    }
}
