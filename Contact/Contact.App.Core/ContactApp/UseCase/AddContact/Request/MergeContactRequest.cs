using Application.UseCase.AddContact.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Contact.App.Core.ContactApp.UseCase.AddContact.Request
{
    public class MergeContactRequest
    {
        public Guid contactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static MergeContactRequest Create(Guid contactId, string firstName, string lastName, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Le prénom ne peut pas être vide.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Le nom ne peut pas être vide.", nameof(lastName));
            if (!IsValidEmail(email))
                throw new ArgumentException("L'email n'est pas valide.", nameof(email));
            if (!IsValidPhoneNumber(phoneNumber))
                throw new ArgumentException("Le numéro de téléphone n'est pas valide.", nameof(phoneNumber));

            return new MergeContactRequest
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
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
        }

    }

}
