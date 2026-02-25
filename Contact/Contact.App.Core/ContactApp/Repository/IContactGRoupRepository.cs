using Contact.App.Core.ContactApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Core.ContactApp.Repository
{
    public interface IContactGroupRepository
    {
        Task<ContactGroup> GetById(Guid id);
        Task Update(ContactGroup group);
    }

}
