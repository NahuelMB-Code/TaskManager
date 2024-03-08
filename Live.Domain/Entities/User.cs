using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Live.Domain.Entities
{
    public partial class User
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<MyTask> Tasks { get; set; } = new List<MyTask>();
    }
}
