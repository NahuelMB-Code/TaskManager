using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Domain.ValueObjets.Task
{
    public record TaskId
    {
        public Guid Value { get; init; } // init quiere decir que no se setea publicamente

        internal TaskId(Guid value)
        {
            Value = value;
        }

        public static TaskId Create(Guid value)
        {
            return new TaskId(value);
        }


        public static implicit operator Guid(TaskId taskId)
        {
            return taskId.Value;
        }
    }
}
