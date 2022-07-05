using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.DTOs.Categories;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.Include(c => c.Notes).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound("Category does not exist");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CreateCategoryDTO categoryDto)
        {
            var newCategory = _mapper.Map<Category>(categoryDto);

            var category = await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] EditCategoryDTO editCategoryDto)
        {
            var categoryToEdit = await _context.Categories.FindAsync(id);
            if (categoryToEdit == null) return NotFound("Category does not exist.");

            _mapper.Map(editCategoryDto, categoryToEdit);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete == null) return NotFound();

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
