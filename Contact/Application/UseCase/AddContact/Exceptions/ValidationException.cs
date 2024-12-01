using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.AddContact.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationError> _errors { get; }

        public ValidationException(List<ValidationError> errors) 
        {
            _errors = errors;
        }

        public ValidationException(string message)
        {
            _errors =[
            new() { Message = message }
        ];
        }
    }
}
