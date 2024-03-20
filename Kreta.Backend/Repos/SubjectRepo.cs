using Kreta.Backend.Context;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace Kreta.Backend.Repos
{
    public class SubjectRepo<TDbContext> : RepositoryBase<TDbContext, Subject>, ISubjectRepo
        where TDbContext : KretaContext
    {
        public SubjectRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<Subject> SelectSubjectsWithSchoolClasses()
        {
            return FindAll()
                .Include(subject => subject.SchoolClassSubjects) 
                .ThenInclude(schoolClassSubject => schoolClassSubject.SchoolClass);
        }
    }
}
