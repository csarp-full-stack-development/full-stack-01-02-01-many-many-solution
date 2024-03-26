using Kreta.Backend.Repos;
using Kreta.Backend.Services;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Models.SwitchTable;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolClassSubjectsController : BaseController<SchoolClassSubjects, SchoolClassSubjectsDto>
    {
        private readonly ISchoolClassSubjectsRepo _repo;
        private readonly ISchoolClassSubjectService? _schoolClassSubjectService;
        public SchoolClassSubjectsController(ISchoolClassSubjectService? schoolClassSubjectService, SchoolClassSubjectsAssambler assambler, ISchoolClassSubjectsRepo repo) : base(assambler, repo)
        {
            _repo = repo;
            _schoolClassSubjectService = schoolClassSubjectService;
        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<Student>? students = new();
            if (_repo != null)
            {
                try
                {
                    List<SchoolClassSubjects> result = await _repo.SelectAllIncluded().ToListAsync();
                    return Ok(result.Select(schoolClassSubjects => schoolClassSubjects.ToDto()));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPost("MoveSubjectToNotStudiedInTheSchoolClass")]
        public async Task<ActionResult> MoveSubjectToNotStudiedInTheSchoolClass(SchoolClassSubjectsDto schoolClassSubjectsDto)
        {
            ControllerResponse response = new();
            if (_schoolClassSubjectService is not null)
            {
                response = await _schoolClassSubjectService.MoveSubjectToNotStudiedInTheSchoolClassAsync(schoolClassSubjectsDto.SubjectId, schoolClassSubjectsDto.SchoolClassId);
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("A tantárgy áthelyezése az osztály által nem tanult tanátrgyak közé nem sikerült!");
                    return BadRequest(response);
                }
            }
            return Ok(response);
        }
    }
}
