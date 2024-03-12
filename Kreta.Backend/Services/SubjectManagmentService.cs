using Kreta.Backend.Repos.Managers;
using Kreta.Shared.Models;
using Kreta.Shared.Models.SwitchTable;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kreta.Backend.Services
{
    public class SubjectManagmentService : ISubjectManagmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        public SubjectManagmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager= repositoryManager;
        }
        public IQueryable<SchoolClass> SelectSchoolClassWhereNotStudiedSubject(Guid subjectId)
        {
            Subject? subjecedSubject= (from subject in _repositoryManager.SubjectRepo?.FindAll()
                                        where subject.Id == subjectId
                                        select subject).FirstOrDefault();
            //ICollection<SchoolClass> SchoolClassWhoStudy = subjecedSubject.SchoolClassSubjects;                                  
            IQueryable<SchoolClass> result = from schoolClassSubjects in    _repositoryManager.SchoolClassSubjectsRepo.FindAll()
                         where schoolClassSubjects.SubjectId == subjectId
                         select schoolClassSubjects.SchoolClass;




            return new Collection<SchoolClass>().AsQueryable();

        }
    }
}
