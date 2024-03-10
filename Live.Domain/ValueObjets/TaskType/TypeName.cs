using Live.Domain.ValueObjets.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Domain.ValueObjets.TaskType
{
    public class TypeName
    {
        public string Name { get; init; } // init quiere decir que no se setea publicamente

        private TypeName () { }
        internal TypeName(string value)
        {
            Name = value;
        }

        public static TypeName Create(string value)
        {
            Validate(value);
            return new TypeName(value);
        }


        public static void Validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El valor no puede ser nullo");
            }
        }
    }
}
