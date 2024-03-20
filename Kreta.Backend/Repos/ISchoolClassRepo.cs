using Kreta.Shared.Models;
using Kreta.Shared.Models.SwitchTable;

namespace Kreta.Backend.Repos
{
    public interface ISchoolClassRepo : IRepositoryBase<SchoolClass>
    {
        public IQueryable<SchoolClass> SelectSchoolClassesWithSubjects();
    }
}
