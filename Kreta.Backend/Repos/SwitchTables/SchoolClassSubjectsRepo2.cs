using Kreta.Backend.Context;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Models.SwitchTable;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos.SwitchTables
{
    public class SchoolClassSubjectsRepo2 : RepositoryBase2<SchoolClassSubjects>, ISchoolClassSubjectsRepo
    {
        public SchoolClassSubjectsRepo2(KretaContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<SchoolClassSubjects> SelectAllIncluded()
        {
            return FindAll().Include(schoolClassSubjects => schoolClassSubjects.Subject)
                            .Include(SchoolClassSubjects => SchoolClassSubjects.SchoolClass);
        }
    }
}
