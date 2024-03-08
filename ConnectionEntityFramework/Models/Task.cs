using System;
using System.Collections.Generic;

namespace ConnectionEntityFramework.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public int? TaskTypeId { get; set; }

    public virtual TaskType? TaskType { get; set; }

    public virtual User? User { get; set; }
}
