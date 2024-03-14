using Kreta.Backend.Context;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace Kreta.Backend.Repos
{
    public class SubjectRepo2: RepositoryBase2<Subject>, ISubjectRepo
    {
        public SubjectRepo2(KretaContext dbContext) : base(dbContext)
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
