using Microsoft.EntityFrameworkCore;
using NotesApi.Models;

namespace NotesApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
    }
}
