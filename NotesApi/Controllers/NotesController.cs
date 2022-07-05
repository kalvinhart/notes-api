using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.DTOs.Notes;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NotesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNotes()
        {
            var notes = await _context.Notes.ToListAsync();
            return Ok(notes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetNote(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note == null) return NotFound();

            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNote(CreateNoteDTO createNoteDto)
        {
            var newNote = _mapper.Map<Note>(createNoteDto);

            await _context.Notes.AddAsync(newNote);
            await _context.SaveChangesAsync();

            return Ok(newNote);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> UpdateNote(int id, [FromBody] UpdateNoteDTO updateNoteDto)
        {
            var noteToBeUpdated = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (noteToBeUpdated == null) return NotFound("Note does not exist.");

            _mapper.Map(updateNoteDto, noteToBeUpdated);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
