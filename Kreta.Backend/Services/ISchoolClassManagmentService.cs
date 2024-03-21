using Kreta.Shared.Models;

namespace Kreta.Backend.Services
{
    public interface ISchoolClassManagmentService
    {
        public IQueryable<Subject> SelectSubjectNoStudiedInTheSchoolClass(Guid schoolClassId);
    }
}
