using Domain.Entities;

public class ContactFactory
{
    
    public static Contact CreateContact(string firstName, string lastName, string phoneNumber, string email)
    {
       
        return new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };
    }

}
