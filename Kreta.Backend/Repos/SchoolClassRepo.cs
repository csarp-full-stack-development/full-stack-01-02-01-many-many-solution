using Kreta.Backend.Context;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class SchoolClassRepo<TDbContext> : RepositoryBase<TDbContext, SchoolClass>, ISchoolClassRepo
        where TDbContext : KretaContext
    {
        public IQueryable<SchoolClass> SelectSchoolClassesWithSubjects()
        {
            return FindAll()
                .Include(schoolClasses => schoolClasses.SchoolClassSubjects)
                .ThenInclude(schoolClassSubjects => schoolClassSubjects.Subject);
        }
    }
}
