using Kreta.Shared.Models;

namespace Kreta.HttpService.Services
{
    public interface ISchoolClassService : IBaseService<SchoolClass>
    {
        public Task<List<SchoolClass>> SelectAllSchoolClassWithSubjectsAsync();
        public Task<List<SchoolClass>> SelectSchoolClassWhoNotStudiedSubject(Guid subjectId);
    }
}
