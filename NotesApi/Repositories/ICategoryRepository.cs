using NotesApi.Models;

namespace NotesApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task<Category> CreateCategory(Category category);
        Task<Boolean> DeleteCategory(int id);
    }
}
