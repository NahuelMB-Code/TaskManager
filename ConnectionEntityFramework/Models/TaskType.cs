using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConnectionEntityFramework.Models;

public partial class TaskType
{
    public int TaskTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
