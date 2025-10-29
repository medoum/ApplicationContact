namespace Contact.App.Core.ContactApp.UseCase.GetSingleContact
{
    public interface IGetSingleContact
    {
        Task<Entity.Contact> GetContact(Guid contactId);
    }
}
