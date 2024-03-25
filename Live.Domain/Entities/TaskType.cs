using Live.Domain.ValueObjets.TaskType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Live.Domain.Entities
{
    public partial class TaskType<T>
    {
        public required T TaskTypeId { get; set; }

        public TypeName TypeName { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<MyTask<T>> Tasks { get; set; } = new List<MyTask<T>>();
    }
}
