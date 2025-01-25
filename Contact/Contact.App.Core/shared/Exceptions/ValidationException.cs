using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.App.Core.shared.Exceptions
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
            _errors = [
            new() { Message = message }
        ];
        }
    }
}
