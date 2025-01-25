using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.UseCase.AddContact.Request
{
    public class AddContactRequest
    {
        Guid id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;

        private AddContactRequest() { }

        public static AddContactRequest Create(Guid id,string firstName, string lastName, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Le prénom ne peut pas être vide.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Le nom ne peut pas être vide.", nameof(lastName));
            if (!IsValidEmail(email))
                throw new ArgumentException("L'email n'est pas valide.", nameof(email));
            if (!IsValidPhoneNumber(phoneNumber))
                throw new ArgumentException("Le numéro de téléphone n'est pas valide.", nameof(phoneNumber));

            return new AddContactRequest
            {
                id = id,
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
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
        }
    }
}
