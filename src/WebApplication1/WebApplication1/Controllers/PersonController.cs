using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[persons]")]
public class PersonController : ControllerBase
{
    private PersonRepository _personRepository;

    public PersonController(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Person>> GetPersons()
    {
        var result = _personRepository.GetAllPersons();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Person> GetPersonById(int id)
    {
        try
        {
            var result = _personRepository.GetPersonById(id);
            return Ok(result);
        }
        catch
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public ActionResult PostPerson(Person person)
    {
        try
        {
            _personRepository.AddPerson(person);
        }
        catch
        {
            return BadRequest();
        }
        return Ok(person.Id);
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeletePerson(int id)
    {
        try
        {
            _personRepository.DeletePerson(id);
        }
        catch
        {
            return NotFound();
        }
        return Ok();

    }
    
    [HttpPatch("{id}")]
    public ActionResult PatchPerson(int id)
    {
        try
        {
            _personRepository.UpdatePerson(id);
        }
        catch
        {
            return NotFound();
        }
        return Ok();
    }
}