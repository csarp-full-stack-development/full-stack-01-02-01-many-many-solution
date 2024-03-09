using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class SchoolClassSubjectsRepo<TDbContext> : RepositoryBase<TDbContext, SchoolClassSubjects>, ISchoolClassSubjectsRepo
        where TDbContext : DbContext
    {
        public SchoolClassSubjectsRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
