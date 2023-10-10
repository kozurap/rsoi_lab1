using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;

namespace WebApplication1.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext context;

        public PersonRepository(PersonContext context)
        {
            this.context = context;
        }

        public async Task<Person> GetPersonById(int Id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == Id);
            if (person is null)
            {
                throw new ArgumentException($"Person with Id {Id} does not exists");
            }
            return person;
        }
        public async Task<IEnumerable<Person>> GetAllPersons() => await context.Persons.ToArrayAsync();
        public async Task AddPerson (Person person)
        {
            var newPerson = await context.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);
            if (newPerson is not null)
            {
                throw new ArgumentException($"Person with Id {person.Id} does exists");
            }
            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePerson(int Id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == Id);
            if (person is null)
            {
                throw new ArgumentException($"Person with Id {Id} does not exists");
            }
            context.Persons.Update(person);
            await context.SaveChangesAsync();
        }
        public async Task DeletePerson(int Id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == Id);
            if (person is null)
            {
                throw new ArgumentException($"Person with Id {Id} does not exists");
            }
            context.Persons.Remove(person);
            await context.SaveChangesAsync();
        }
    }
}
