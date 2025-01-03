

namespace Application.Interfaces
{
    public interface IDeleteContactUseCase
    {
        Task DeleteContactUseCaseAsync(string email);
    }
}
