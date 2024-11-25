using ASP_Contact.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Contact.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFiltered(string filter)
        {
            return Ok(_context.Organizations
                .Where(o => o.Name.StartsWith(filter))
                .Select(o => new { o.Name, o.Id })
                .ToList());
        }
    }
}
