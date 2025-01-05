namespace Contact.App.Core.Contact.UseCase.Delete
{
    public interface IDeleteContactUseCase
    {
        Task DeleteContactUseCaseAsync(Guid Id);
    }
}
