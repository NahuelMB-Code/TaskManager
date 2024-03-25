namespace Live.Api.Commands
{
    public record CreateTaskCm<T>(T TaskId, string Name);
}
