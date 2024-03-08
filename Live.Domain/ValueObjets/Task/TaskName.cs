using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Domain.ValueObjets.Task
{
    public record TaskName
    {
        public string Name { get; init; } // init quiere decir que no se setea publicamente

        internal TaskName(string value)
        {
            Name = value;
        }

        public static TaskName Create(string value)
        {
            Validate(value);
            return new TaskName(value);
        }


        public static void Validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nulo");
            }
        }
    }
}
