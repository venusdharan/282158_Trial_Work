using _282158_Trial_Work.Data;
using Microsoft.AspNetCore.Mvc;

namespace _282158_Trial_Work.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonDataController : ControllerBase
    {
        private readonly PersonDataContext _context;

        public PersonDataController(PersonDataContext context)
        {
            _context = context;
        }

        [HttpGet] // Use the HTTP GET method to retrieve all persons
        public IActionResult GetAllPersons()
        {
            var allPersons = _context.Persons.ToList(); // Retrieve all persons from the database

            if (allPersons.Count == 0)
            {
                return NotFound(); // Return a 404 Not Found if no persons are found
            }

            return Ok(allPersons); // Return the list of persons with a 200 OK status
        }

        [HttpGet("changes")]
        public IActionResult GetChanges(DateTime startDate, DateTime endDate)
        {
            var changes = _context.Persons
                .Where(p => p.DateOfDeath != null &&
                            p.DateOfDeath >= startDate &&
                            p.DateOfDeath <= endDate)
                .Select(p => new
                {
                    PersonalIdentificationNumber = p.PersonalCode,
                    Changes = new List<string> { "Death" }
                })
                .ToList();

            return Ok(changes);
        }
    }
}
