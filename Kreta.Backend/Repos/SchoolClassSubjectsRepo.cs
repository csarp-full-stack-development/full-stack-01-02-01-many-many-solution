using Kreta.Shared.Models;
using Kreta.Shared.Models.SchoolCitizens;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class SchoolClassSubjectsRepo<TDbContext> : RepositoryBase<TDbContext, SchoolClassSubjects>, ISchoolClassSubjectsRepo
        where TDbContext : DbContext
    {
        public SchoolClassSubjectsRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public IQueryable<SchoolClassSubjects> SelectAllIncluded()
        {
            return FindAll().Include(schoolClassSubjects => schoolClassSubjects.Subject)
                            .Include(SchoolClassSubjects => SchoolClassSubjects.SchoolClass);
        }
    }
}
