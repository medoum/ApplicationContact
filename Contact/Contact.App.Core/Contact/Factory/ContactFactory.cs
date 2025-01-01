using Contact.App.Core.Contact.Entities;

public class ContactFactory
{
    
    public static ContactDto CreateContact(string firstName, string lastName, string phoneNumber, string email)
    {
       
        return new ContactDto
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };
    }

}
