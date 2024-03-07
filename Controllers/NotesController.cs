using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

[Route("[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly NoteDbContext _context;

    public NotesController(NoteDbContext context)
    {
        _context = context;
    }

    // GET: api/Notes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<NotesTable>> GetNote(int id)
    {
        var note = await _context.Notes.FindAsync(id);

        if (note == null)
        {
            return NotFound();
        }

        return note;
    }

    // GET: Notes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotesTable>>> GetNotes()
    {
        return await _context.Notes.ToListAsync();
    }

    // POST: Notes
    [HttpPost]
    public async Task<ActionResult<NotesTable>> CreateNote(NotesTable noteDto)
    {
        var note = new NotesTable
        {
            TitleNote = noteDto.TitleNote,
            TextNote = noteDto.TextNote,
            DateCreate = noteDto.DateCreate,
        };

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetNote), new { id = note.IdNote }, note);
    }

    // DELETE: api/Notes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        if (note == null)
        {
            return NotFound();
        }

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();

        return NoContent(); // Возвращает статус 204 No Content в случае успеха
    }

    // PUT: api/Notes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, NotesTable noteUpdateDto)
    {

        noteUpdateDto.IdNote = id;

        _context.Entry(noteUpdateDto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Notes.Any(e => e.IdNote == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // Возвращает статус 204 No Content в случае успеха
    }
}
