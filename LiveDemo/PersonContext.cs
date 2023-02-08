using Microsoft.EntityFrameworkCore;

namespace LiveDemo;

public class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public PersonContext(DbContextOptions options) : base(options)
    {
        
    }
}