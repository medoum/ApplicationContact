using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Core.ContactApp.UseCase.MoveContact.Request
{
    public class MoveContactRequest
    {
        public Guid FromGroupId { get; set; }
        public Guid ToGroupId { get; set; }
    }
}
