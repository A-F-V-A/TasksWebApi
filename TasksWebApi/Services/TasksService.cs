using TasksWebApi.Models;

namespace TasksWebApi.Services
{
    public class TasksService : ITasksService
    {

        TaskContext context;

        public TasksService(TaskContext context) => this.context = context;

        public IEnumerable<Tasks> Get() => context.Tasks;

        public async Task Save(Tasks tasks)
        {
            context.Add(tasks);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tasks tasks)
        {
            Tasks findTask = context.Tasks.Find(id)!;

            if (findTask != null)
            {
                findTask.CategoryId = tasks.CategoryId;
                findTask.Title = tasks.Title;
                findTask.Description = tasks.Description;
                findTask.Priority = tasks.Priority;
                await context.SaveChangesAsync();
            }
        }

        public async Task Remove(Guid id)
        {
            Tasks findTask = context.Tasks.Find(id)!;

            if (findTask != null)
            {
                context.Remove(findTask);
                await context.SaveChangesAsync();
            }

        }
    }

    public interface ITasksService
    {
        public IEnumerable<Tasks> Get();
        public Task Save(Tasks tasks);
        public Task Update(Guid id, Tasks tasks);
        public Task Remove(Guid id);
    }
}

