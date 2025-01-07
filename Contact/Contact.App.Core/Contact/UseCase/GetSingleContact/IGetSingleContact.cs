namespace Contact.App.Core.Contact.UseCase.GetSingleContact
{
     public interface IGetSingleContact
     {
        Task<Entity.Contact> GetContact(Guid contactId);
     }
}
