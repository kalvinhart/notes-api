using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.DTOs.Categories;
using NotesApi.Models;
using NotesApi.Repositories;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null) return NotFound("Category does not exist");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CreateCategoryDTO categoryDto)
        {
            var newCategory = _mapper.Map<Category>(categoryDto);

            var category = await _categoryRepository.CreateCategory(newCategory);

            return Ok(category);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryRepository.DeleteCategory(id);
            if (categoryToDelete == false) return NotFound();

            return Ok();
        }
    }
}
