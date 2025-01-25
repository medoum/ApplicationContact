namespace Contact.App.Core.ContactApp.Entity;

     public interface IGetSingleContact
     {
        Task<Contact> GetContact(Guid contactId);
     }

