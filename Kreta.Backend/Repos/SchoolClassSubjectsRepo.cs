using Kreta.Backend.Context;
using Kreta.Shared.Models.SwitchTable;

namespace Kreta.Backend.Repos
{
    public class SchoolClassSubjectsRepo<TDbConext> : RepositoryBase<TDbConext, SchoolClassSubjects>, ISchoolClassSubjectsRepo
        where TDbConext : KretaContext
    {
        public SchoolClassSubjectsRepo(TDbConext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<SchoolClassSubjects> SelectAllIncluded()
        {
            
        }
    }
}
