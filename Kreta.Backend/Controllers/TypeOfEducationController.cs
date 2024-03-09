using Kreta.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeOfEducationController : BaseController<TypeOfEducation, TypeOfEducationDto>
    {
        public TypeOfEducationController(TypeOfEducationAssambler assambler, ITypeOfEducationRepo repo) : base(assambler, repo)
        {
        }
    }
}
