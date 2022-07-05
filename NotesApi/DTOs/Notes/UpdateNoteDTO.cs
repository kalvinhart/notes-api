namespace NotesApi.DTOs.Notes
{
    public class UpdateNoteDTO
    {
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
