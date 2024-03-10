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
    public class SubjectController : BaseController<Subject, SubjectDto>
    {
        private readonly ISubjectRepo _subjectRepo;
        public SubjectController(SubjectAssambler assambler, ISubjectRepo repo) : base(assambler, repo)
        {
            _subjectRepo = repo;
        }

        [HttpGet("withschoolclass")]
        public async Task<IActionResult> SelectSubjectsWithSchoolClass()
        {
            List<Subject> subjects = new List<Subject>();
            if (_subjectRepo is not null)
            {
                try
                {
                    List<Subject> result = await _subjectRepo.SelectSubjectsWithSchoolClasses().ToListAsync();
                    return Ok(result.Select(subject => subject.ToDto()));
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
