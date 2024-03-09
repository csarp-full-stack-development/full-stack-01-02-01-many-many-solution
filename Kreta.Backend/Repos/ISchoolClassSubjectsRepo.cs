using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public interface ISchoolClassSubjectsRepo : IRepositoryBase<SchoolClassSubjects>
    {
        public IQueryable<SchoolClassSubjects> SelectAllIncluded();
    }
}
