using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.App.Core.shared.Exceptions
{
    public static class InvalidError
    {
        public const string ContactAlreadyExists = "Un contact avec cet email ou numéro de téléphone existe déjà";
    }
}
