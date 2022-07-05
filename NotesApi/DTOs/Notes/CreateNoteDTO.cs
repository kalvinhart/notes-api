namespace NotesApi.DTOs.Notes
{
    public class CreateNoteDTO
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
