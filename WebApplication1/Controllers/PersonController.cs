using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

[ApiController]
[Route("persons")]
public class PersonController : ControllerBase
{
    private IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
    {
        var result = await _personRepository.GetAllPersons();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetPersonById(int id)
    {
        try
        {
            var result = await _personRepository.GetPersonById(id);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> PostPerson(Person person)
    {
        try
        {
            await _personRepository.AddPerson(person);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        var personId = person.Id;
        return Created($"persons/{personId}", null);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePerson(int id)
    {
        try
        {
            await _personRepository.DeletePerson(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();

    }
    
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchPerson(int id)
    {
        try
        {
            await _personRepository.UpdatePerson(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();
    }
}