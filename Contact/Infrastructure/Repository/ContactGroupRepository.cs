using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;

public class ContactGroupRepository : IContactGroupRepository
{
    private readonly List<ContactGroup> _groups = new();

    public void Add(ContactGroup contactGroup)
        => _groups.Add(contactGroup);

    public void Delete(Guid id)
        => _groups.RemoveAll(g => g.GetId() == id);

    public ContactGroup? GetById(Guid id)
        => _groups.FirstOrDefault(g => g.GetId() == id);

    public ContactGroup? GetByName(string name)
        => _groups.FirstOrDefault(g => g.GetName() == name);

    public List<ContactGroup> GetAll()
        => _groups.ToList();

    public void Update(ContactGroup contactGroup)
    {
        var index = _groups.FindIndex(g => g.GetId() == contactGroup.GetId());
        if (index >= 0)
            _groups[index] = contactGroup;
    }
}
