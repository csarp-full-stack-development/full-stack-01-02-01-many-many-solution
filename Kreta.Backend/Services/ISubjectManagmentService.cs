using Kreta.Shared.Models;

namespace Kreta.Backend.Services
{
    public interface ISubjectManagmentService
    {
        public IQueryable<SchoolClass> SelectSchoolClassWhoNotStudyingSubject(Guid subjectId);
    }
}
