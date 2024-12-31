using System.Text.RegularExpressions;

namespace Application.UseCase.AddContact.Request
{
    public class AddContactRequest
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public static AddContactRequest Create(string firstName, string lastName, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("Le prénom ne peut pas être vide.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Le nom ne peut pas être vide.");
            if (!IsValidEmail(email)) throw new ArgumentException("L'email n'est pas valide.");
            if (!IsValidPhoneNumber(phoneNumber)) throw new ArgumentException("Le numéro de téléphone n'est pas valide.");

            return new AddContactRequest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit);
        }
    }



}