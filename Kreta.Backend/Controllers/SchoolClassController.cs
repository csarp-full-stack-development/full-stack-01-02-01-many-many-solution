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
    public class SchoolClassController : BaseController<SchoolClass, SchoolClassDto>
    {
        private readonly ISchoolClassRepo _repo;
        private readonly ISubjectManagmentService? _subjectManagmentService;
        public SchoolClassController(ISubjectManagmentService subjectManagmentService, SchoolClassAssambler assambler, ISchoolClassRepo repo) : base(assambler, repo)
        {
            _repo = repo;
            _subjectManagmentService = subjectManagmentService;
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

        [HttpGet("wherenostudiedsubject/{subjectId}")]
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
