namespace Contact.App.Core.ContactApp.Entity;

using System;

public class Contact
{
    private Guid _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phoneNumber;
    private string _additionalPhoneNumber;

    private Contact(string firstName, string lastName, string email, string phoneNumber)
    {
        _id = Guid.NewGuid(); 
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _phoneNumber = phoneNumber;


    }

    public Guid GetId()
    {
        return _id;
    }

    public string GetFirstName()
    {
        return _firstName;
    }
    public void SetFirstName(string firstName)
    {
        if (!string.IsNullOrEmpty(firstName))
        {
            _firstName = firstName;
        }
    }
    public string GetLastName()
    {
        return _lastName;
    }
    public void SetLastName(string lastName)
    {
        if (!string.IsNullOrEmpty(lastName))
        {
            _lastName = lastName;
        }
    }
    public string GetEmail()
    {
        return _email;
    }
    public void SetEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            _email = email;
        }
    }
  

    public string GetPhoneNumber()
    {
        return _phoneNumber;
    }
    public void SetPhoneNumber(string phoneNumber)
    {
        if (!string.IsNullOrEmpty(phoneNumber))
        {
            _phoneNumber = phoneNumber;
        }
    }
    public string GetAdditionalPhoneNumber()
    {
        return _additionalPhoneNumber;
    }

    public static Contact CreateContact(string firstName, string lastName, string phoneNumber, string email)
     {
            return new Contact(firstName, lastName, email, phoneNumber);
     }
    public bool IsValid()
    {
        return _id != Guid.Empty
            && !string.IsNullOrWhiteSpace(_firstName)
            && !string.IsNullOrWhiteSpace(_lastName)
            && !string.IsNullOrWhiteSpace(_email);
    }
    public bool MergeWith(string firstName, string lastName, string phoneNumber, string email)
    {
        bool hasChanges = false;

        if (_firstName != firstName && !string.IsNullOrWhiteSpace(firstName))
        {
            _firstName = firstName;
            hasChanges = true;
        }

        if (_lastName != lastName && !string.IsNullOrWhiteSpace(lastName))
        {
            _lastName = lastName;
            hasChanges = true;
        }

        if (_phoneNumber != phoneNumber && !string.IsNullOrWhiteSpace(phoneNumber))
        {
            _phoneNumber = phoneNumber;
            hasChanges = true;
        }

        if (_email != email && !string.IsNullOrWhiteSpace(email))
        {
            _email = email;
            hasChanges = true;
        }


        return hasChanges;
    }
    public bool ReplaceWith(string firstName, string lastName, string phoneNumber, string email)
    {
        bool hasChanges = false;

        if (!string.IsNullOrWhiteSpace(firstName) && _firstName != firstName)
        {
            _firstName = firstName;
            hasChanges = true;
        }

        if (!string.IsNullOrWhiteSpace(lastName) && _lastName != lastName)
        {
            _lastName = lastName;
            hasChanges = true;
        }

        if (!string.IsNullOrWhiteSpace(phoneNumber) && _phoneNumber != phoneNumber)
        {
            _phoneNumber = phoneNumber;
            hasChanges = true;
        }

        if (!string.IsNullOrWhiteSpace(email) && _email != email)
        {
            _email = email;
            hasChanges = true;
        }

    

        return hasChanges;
    }



}

