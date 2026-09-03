using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object id) 
            : base($"{entityName} with id '{id}' was not found.") { }
    }
}
