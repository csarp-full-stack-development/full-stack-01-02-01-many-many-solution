using Kreta.Shared.Models.SwitchTable;

namespace Kreta.Backend.Repos
{
    public interface ISchoolClassSubjectsRepo : IRepositoryBase<SchoolClassSubjects>
    {
        public IQueryable<SchoolClassSubjects> SelectAllIncluded();
    }
}
