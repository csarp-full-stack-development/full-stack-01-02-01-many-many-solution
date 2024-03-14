using Kreta.Backend.Context;
using Kreta.Shared.Models;
using Kreta.Shared.Models.SchoolCitizens;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class SchoolClassRepo2 : RepositoryBase2<SchoolClass>, ISchoolClassRepo
    {
        public SchoolClassRepo2(KretaInMemoryContext dbContext) : base(dbContext)
        {
        }
        
        public IQueryable<SchoolClass> SelectSchoolClassesWithSubjects()
        {
            return FindAll()
                .Include(schoolClasses => schoolClasses.SchoolClassSubjects)
                .ThenInclude(schoolClassSubjects => schoolClassSubjects.Subject);
        }
    }
}
