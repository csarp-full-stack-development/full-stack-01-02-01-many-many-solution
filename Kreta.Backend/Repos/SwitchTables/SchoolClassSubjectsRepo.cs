using Kreta.Backend.Context;
using Kreta.Shared.Models.SwitchTable;
using Kreta.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos.SwitchTables
{
    public class SchoolClassSubjectsRepo<TDbContext> : RepositoryBase<TDbContext, SchoolClassSubjects>, ISchoolClassSubjectsRepo
        where TDbContext : KretaContext
    {
        public SchoolClassSubjectsRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<SchoolClassSubjects> SelectAllIncluded()
        {
            return FindAll().Include(schoolClassSubjects => schoolClassSubjects.Subject)
                            .Include(SchoolClassSubjects => SchoolClassSubjects.SchoolClass);
        }

        public async ControllerResponse MoveSubjectToNotStudiedInTheSchoolClass(Guid schoolClassId, Guid subjectID)
        {
            SchoolClassSubjects? schoolClassSubject = FindByCondition(schoolClassSubjects => schoolClassSubjects.SchoolClassId == schoolClassId && schoolClassSubjects.SubjectId==subjectID).FirstOrDefault();
            if (schoolClassSubject is not null) 
            {
                await 
            }
            
        }
    }
}
