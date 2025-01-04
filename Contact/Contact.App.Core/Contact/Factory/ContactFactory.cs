using Contact.App.Core.Contact.Entities;

public class ContactFactory
{
    
    public static Contact.App.Core.Contact.Entities.Contact CreateContact(string firstName, string lastName, string phoneNumber, string email)
    {
       
        return new Contact.App.Core.Contact.Entities.Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };
    }

}
