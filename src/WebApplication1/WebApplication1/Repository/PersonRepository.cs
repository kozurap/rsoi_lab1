using WebApplication1.Domain;

namespace WebApplication1.Repository
{
    public class PersonRepository
    {
        PersonContext context;

        PersonRepository(PersonContext context)
        {
            this.context = context;
        }

        public Person GetPersonById(int Id)
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == Id);
            if (person is null)
            {
                throw new Exception($"Person with Id {Id} does not exists");
            }
            return person;
        }
        public IEnumerable<Person> GetAllPersons() => context.Persons.ToArray();
        public void AddPerson (Person person)
        {
            var newPerson = context.Persons.FirstOrDefault(x => x.Id == person.Id);
            if (person is not null)
            {
                throw new Exception($"Person with Id {person.Id} does exists");
            }
            context.Persons.Add(person);
        }
        public void UpdatePerson (int Id)
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == Id);
            if (person is null)
            {
                throw new Exception($"Person with Id {Id} does not exists");
            }
            context.Persons.Update(person);
        }
        public void DeletePerson(int Id)
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == Id);
            if (person is null)
            {
                throw new Exception($"Person with Id {Id} does not exists");
            }
            context.Persons.Remove(person);
        }
    }
}
