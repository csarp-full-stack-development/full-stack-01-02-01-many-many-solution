using Kreta.Backend.Repos;
using Kreta.Backend.Services;
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
        private readonly ISubjectManagmentService? _subjectManagmentService;
        public SubjectController(ISubjectManagmentService subjectManagmentService, SubjectAssambler assambler, ISubjectRepo repo) : base(assambler, repo)
        {
            _subjectRepo = repo;
            _subjectManagmentService = subjectManagmentService;
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

        [HttpGet("wherenostudysubject/{subjectId}")]
        public async Task<IActionResult> SelectSchoolClassWhoNotStudiedSubject(Guid subjectId)
        {
            List<SchoolClass> schoolClasses = new List<SchoolClass>();
            if (_subjectManagmentService is not null)
            {
                try
                {
                    List<SchoolClass> result = await _subjectManagmentService
                        .SelectSchoolClassWhoNotStudiedSubject(subjectId)
                        .ToListAsync();
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
