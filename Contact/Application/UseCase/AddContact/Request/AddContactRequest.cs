using System;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCase.AddContact.Request
{
    public class AddContactRequest
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }



        public AddContactRequest(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void setFirstName(string firstName) 
        {
            if (!string.IsNullOrEmpty(firstName)) 
            {
                FirstName = firstName;
            }
        }
        public void setLastName(string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                LastName = lastName;
            }
        }
        public void setEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Email = email;
            }
        }
        public void setPhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                LastName = phoneNumber;
            }
        }

      

    }

   
}