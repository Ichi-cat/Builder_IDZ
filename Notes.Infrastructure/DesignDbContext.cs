using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Notes.Persistence
{
    public class DesignDbContext : IDesignTimeDbContextFactory<NotesDbContext>
    {
        public NotesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotesDbContext>();

            optionsBuilder.UseSqlite("Data Source=Notes.db");
            return new NotesDbContext(optionsBuilder.Options);
        }
    }
}
