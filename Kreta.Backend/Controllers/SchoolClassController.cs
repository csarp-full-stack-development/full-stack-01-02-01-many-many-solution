using Kreta.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolClassController : BaseController<SchoolClass, SchoolClassDto>
    {
        private readonly ISchoolClassRepo _repo;
        public SchoolClassController(SchoolClassAssambler assambler, ISchoolClassRepo repo) : base(assambler, repo)
        {
            _repo = repo;
        }

        [HttpGet("withsubjects")]
        public async Task<IActionResult> SelectSchoolClassWithSubjects()
        {
            List<SchoolClass> schoolClasses = new List<SchoolClass>();
            if (_repo is not null)
            {
                try
                {
                    List<SchoolClass> result = await _repo.SelectSchoolClassesWithSubjects().ToListAsync();
                    return Ok(result.Select(schoolClass => schoolClass.ToDto()));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
    }
}
