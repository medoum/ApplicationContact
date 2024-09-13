using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.AddContact.Result
{
    public class AddContactResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public AddContactResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
