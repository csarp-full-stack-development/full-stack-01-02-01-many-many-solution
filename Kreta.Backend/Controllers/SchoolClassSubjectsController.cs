using Kreta.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolClassSubjectsController : BaseController<SchoolClassSubjects, SchoolClassSubjectsDto>
    {
        public SchoolClassSubjectsController(SchoolClassSubjectsAssambler assambler, ISchoolClassSubjectsRepo repo) : base(assambler, repo)
        {
        }
    }
}
