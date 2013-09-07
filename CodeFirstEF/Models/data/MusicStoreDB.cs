using System.Data.Entity;

namespace CodeFirstEF.Models.data
{
    public class MusicStoreDB : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}