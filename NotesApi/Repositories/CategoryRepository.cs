using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.Models;

namespace NotesApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Boolean> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete == null) return false;

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return  await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.Include(c => c.Notes).FirstAsync(c => c.Id == id);
        }
    }
}
