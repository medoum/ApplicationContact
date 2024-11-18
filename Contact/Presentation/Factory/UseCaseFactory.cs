using Domain.Interface;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.AddContact.Factory
{
    public class UseCaseFactory
    {
        public static AddContactUseCase CreateAddContactUseCase()
        {
            var contactRepository = new ContactRepository();
            return new AddContactUseCase(contactRepository);
        }
    }
}
