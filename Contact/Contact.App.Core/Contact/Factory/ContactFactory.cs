using Contact.App.Core.Contact.Entity;

public class ContactFactory
{
    
    public static Contact.App.Core.Contact.Entity.Contact CreateContact(string firstName, string lastName, string phoneNumber, string email)
    {
       
        return new Contact.App.Core.Contact.Entity.Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };
    }

}
