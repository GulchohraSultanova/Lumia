using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Property {  get; set; }
        public NotFoundException(string property, string? message) : base(message)
        {
            Property = property;
        }
    }
}
