using InfocomTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InfocomTestTask.Data
{
    public class PersonContext: DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {  
        }

        public DbSet<Person> People { get; set; }
    }
}
