using Live.Domain.ValueObjets.Task;
using System.Diagnostics.Tracing;
using System.Text.Json.Serialization;


namespace Live.Domain.Entities
{
    public partial class MyTask<T>
    {
        public T TaskId { get; set; }

        public TaskName TaskName { get; set; } = null!;
        public string? Description { get; set; }

        public DateOnly? DueDate { get; set; }

        public string? Status { get; set; }

        public T? UserId { get; set; }

        public T? TaskTypeId { get; set; }

        public virtual TaskType<T>? TaskType { get; set; }

        public virtual User<T>? User { get; set; }

        public MyTask(T taskId)
        {
            this.TaskId = taskId;
        }

        public MyTask() { }


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
