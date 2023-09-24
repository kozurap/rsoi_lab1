using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;

namespace WebApplication1
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base()
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
