using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public interface IAddContactGroup
    {
        Task<Guid> Execute(AddContactGroupRequest request);
    }
}
