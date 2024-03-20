using Kreta.Shared.Models;

namespace Kreta.HttpService.Services
{
    public interface ISubjectService : IBaseService<Subject>
    {
        public Task<List<Subject>> GetAllSubjectWithSchoolClassAsync();
        Task<List<Subject>> GetSubjectWhoNotStudySchoolClass(Guid id);
    }
}
