using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConnectionEntityFramework.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
