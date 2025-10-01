using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Core.ContactApp.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IContactGRoupRepository ContactGroups { get; }
        IContactRepository Contacts { get; }

        Task<int> SaveChangesAsync();
    }
}
