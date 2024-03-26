using Kreta.Shared.Dtos;
using Kreta.Shared.Models.SwitchTable;
using Kreta.Shared.Responses;

namespace Kreta.HttpService.Services
{
    public interface ISchoolClassSubjectsService
    {
        public Task<List<SchoolClassSubjects>> SelectAllIncludedAsync();
        public Task<ControllerResponse> MoveSubjectToNotStudiedInTheSchoolClass(SchoolClassSubjects schoolClassSubjectsIdsDto);
    }
}
