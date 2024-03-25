using Kreta.Shared.Models;

namespace Kreta.Backend.Services
{
    public interface ISchoolClassSubjectService
    {
        public IQueryable<Subject> SelectSubjectNoStudiedInTheSchoolClass(Guid schoolClassId);
        public IQueryable<SchoolClass> SelectSchoolClassWhoNotStudyingSubject(Guid subjectId);
        public Task MoveSubjectToNotStudiedInTheSchoolClass(Guid subjectId, Guid schoolClassId);
    }
}
