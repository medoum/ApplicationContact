using Contact.App.Core.Contact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Core.Contact.UseCase.Update
{
    public interface IUpdateContactUseCase
    {
        Task UpdateContactUseCaseAsync(Entities.Contact contact);
    }
}
