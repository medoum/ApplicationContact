namespace Contact.App.Core.ContactApp.Entity;

public class Contact
{
    private Guid _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phoneNumber;
    private string _additionalPhoneNumber;

    private readonly List<Guid> _groupIds = new();

    public Guid Id => _id;
    public IReadOnlyCollection<Guid> GroupIds => _groupIds.AsReadOnly();

    private Contact(string firstName, string lastName, string email, string phoneNumber)
    {
        _id = Guid.NewGuid();
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _phoneNumber = phoneNumber;
    }

    public static Contact Create(
        string firstName,
        string lastName,
        string phoneNumber,
        string email,
        Guid defaultGroupId)
    {
        var contact = new Contact(firstName, lastName, email, phoneNumber);

        contact._groupIds.Add(defaultGroupId);

        return contact;
    }

    public bool AddToGroup(Guid groupId)
    {
        if (_groupIds.Contains(groupId))
            return false;

        _groupIds.Add(groupId);
        return true;
    }


    public void RemoveFromGroup(Guid groupId)
    {
        _groupIds.Remove(groupId);
    }

    public void Update(string firstName, string lastName, string phone, string email)
    {
        if (!string.IsNullOrWhiteSpace(firstName))
            _firstName = firstName;

        if (!string.IsNullOrWhiteSpace(lastName))
            _lastName = lastName;

        if (!string.IsNullOrWhiteSpace(phone))
            _phoneNumber = phone;

        if (!string.IsNullOrWhiteSpace(email))
            _email = email;
    }
}
