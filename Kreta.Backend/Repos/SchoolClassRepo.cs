using Kreta.Backend.Context;
using Kreta.Shared.Models;
using Kreta.Shared.Models.SwitchTable;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class SchoolClassRepo<TDbContext> : RepositoryBase<TDbContext, SchoolClass>, ISchoolClassRepo
        where TDbContext : KretaContext
    {
        public SchoolClassRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<SchoolClass> SelectSchoolClassesWithSubjects()
        {
            return FindAll()
                    .Include(schoolClasses => schoolClasses.SchoolClassSubjects)
                    .ThenInclude(schoolClassSubjects => schoolClassSubjects.Subject);
            //return Enumerable.Empty<SchoolClass>().AsQueryable().AsNoTracking();
        }
    }
}
