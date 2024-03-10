using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Kreta.Backend.Repos
{
    public class SubjectRepo<TDbContext> : RepositoryBase<TDbContext, Subject>, ISubjectRepo
        where TDbContext : DbContext
    {
        public SubjectRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }

        public IQueryable<Subject> SelectSubjectsWithSchoolClasses()
        {
            return FindAll()
                .Include(subject => subject.SchoolClasses)
                .ThenInclude(schoolClassSubject => schoolClassSubject.SchoolClass);
        }
    }
}
