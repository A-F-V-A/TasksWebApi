using TasksWebApi.Models;

namespace TasksWebApi.Services
{
    public class CategoryService : ICategoryService
    {
        TaskContext context;

        public CategoryService(TaskContext context) => this.context = context;

        public IEnumerable<Category> Get()
        {
            return context.Categories;
        }

        public async Task Save(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Category category)
        {
            Category findCategory = context.Categories.Find(id)!;

            if (findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.Description = category.Description;
                findCategory.Difficulty = category.Difficulty;
                await context.SaveChangesAsync();
            }
        }

        public async Task Remove(Guid id)
        {
            Category findCategory = context.Categories.Find(id)!;

            if (findCategory != null)
            {
                context.Remove(findCategory);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoryService
    {
        public IEnumerable<Category> Get();
        public Task Save(Category category);
        public Task Update(Guid id, Category category);
        public Task Remove(Guid id);
    }
}
