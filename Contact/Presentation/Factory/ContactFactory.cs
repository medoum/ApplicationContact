using Domain.Entities;

public static class ContactFactory
{
    public static Contact CreateContact(string firstName, string lastName, string phoneNumber, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("Le prénom ne peut pas être vide.");
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Le nom ne peut pas être vide.");
        if (!IsValidEmail(email)) throw new ArgumentException("L'email n'est pas valide.");
        if (!IsValidPhoneNumber(phoneNumber)) throw new ArgumentException("Le numéro de téléphone n'est pas valide.");

        return new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };
    }

    private static bool IsValidEmail(string email)
    {
        return email.Contains("@"); 
    }

    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        return phoneNumber.All(char.IsDigit);
    }
}
