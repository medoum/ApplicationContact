namespace Contact.App.Core.Contact.UseCase.Delete
{
    public interface IDeleteContactUseCase
    {
        Task DeleteContactUseCaseAsync(string email);
    }
}
