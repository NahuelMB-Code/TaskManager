using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.Domain.ValueObjets.Task
{
    public record TaskId<T>
    {
        public T Value { get; init; } // init quiere decir que no se setea publicamente

        internal TaskId(T value)
        {
            Value = value;
        }

        public static TaskId<T> Create(T value)
        {
            return new TaskId<T>(value);
        }


        public static implicit operator T(TaskId<T> taskId)
        {
            return taskId.Value;
        }
    }
}
