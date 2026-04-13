namespace Contact.App.Core.ContactApp.Entity;

public class ContactGroup
{
    private Guid _id;
    private string _name;
    private bool _isDefault;
    private int _contactsCount;

    private ContactGroup(string name, bool isDefault = false)
    {
        _id = Guid.NewGuid();
        _name = name;
        _isDefault = isDefault;
        _contactsCount = 0;
    }

    public Guid Id => _id;
    public string Name => _name;
    public bool IsDefault => _isDefault;
    public int ContactsCount => _contactsCount;

    public static ContactGroup Create(string name, bool isDefault = false)
        => new ContactGroup(name, isDefault);

    public void IncrementContacts()
    {
        _contactsCount++;
    }

    public void DecrementContacts()
    {
        if (_contactsCount == 0)
            throw new Exception("Impossible de décrémenter. Compteur déjà à 0.");

        _contactsCount--;
    }
}
