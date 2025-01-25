

namespace Contact.App.Core.ContactApp.Entity;

    public interface IUpdateContactUseCase
    {
        Task UpdateContactUseCaseAsync(Contact contact);
    }

