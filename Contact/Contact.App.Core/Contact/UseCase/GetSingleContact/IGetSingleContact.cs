namespace Contact.App.Core.Contact.UseCase.GetSingleContact
{
     public interface IGetSingleContact
     {
        Task GetContact(Guid contactId);
     }
}
