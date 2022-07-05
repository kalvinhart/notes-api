using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.Include(c => c.Notes).FirstAsync(c => c.Id == id);
            if (category == null) return NotFound("Category does not exist");

            return Ok(category);
        }
    }
}
