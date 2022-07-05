namespace NotesApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Note> Notes { get; set; } = new List<Note> { };
    }
}
