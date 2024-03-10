using Live.Domain.ValueObjets.Task;
using System.Diagnostics.Tracing;
using System.Text.Json.Serialization;


namespace Live.Domain.Entities
{
    public partial class MyTask
    {
        public Guid TaskId { get; set; }

        public TaskName TaskName { get; set; } = null!;

        public string? Description { get; set; }

        public DateOnly? DueDate { get; set; }

        public string? Status { get; set; }

        public Guid? UserId { get; set; }

        public Guid? TaskTypeId { get; set; }

        public virtual TaskType? TaskType { get; set; }

        public virtual User? User { get; set; }

        public MyTask(Guid taskId)
        {
            this.TaskId = taskId;
        }


        public void SetName(TaskName name)
        {
            this.TaskName = name;
        }

        /*
         * Se implementaría un método 'set' para cada propiedad de los objetos de valor.
         * La complejidad y las validaciones se delegarían internamente en cada objeto de valor. 
         * Alternativamente, también es posible incorporar validaciones directamente dentro de la entidad principal.
         */

    }

}
