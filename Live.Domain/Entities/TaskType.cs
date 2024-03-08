using Live.Domain.ValueObjets.TaskType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Live.Domain.Entities
{
    public partial class TaskType
    {
        public Guid TaskTypeId { get; set; }

        public TypeName TypeName { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<MyTask> Tasks { get; set; } = new List<MyTask>();
    }
}
