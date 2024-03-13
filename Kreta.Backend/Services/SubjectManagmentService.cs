using Kreta.Backend.Repos.Managers;
using Kreta.Shared.Models;
using Kreta.Shared.Models.SwitchTable;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kreta.Backend.Services
{
    public class SubjectManagmentService : ISubjectManagmentService
    {
        private readonly IRepositoryManager? _repositoryManager;
        public SubjectManagmentService(IRepositoryManager? repositoryManager)
        {
            _repositoryManager= repositoryManager;
        }
        public IQueryable<SchoolClass> SelectSchoolClassWhoNotStudiedSubject(Guid subjectId)
        {
            if (_repositoryManager is not null && _repositoryManager.SchoolClassSubjectsRepo is not null)
            {

                /*Subject? selectedSubject= (from subject in _repositoryManager.SubjectRepo?.FindAll()
                                            where subject.Id == subjectId
                                            select subject).FirstOrDefault();*/
                //ICollection<SchoolClass> SchoolClassWhoStudy = subjecedSubject.SchoolClassSubjects;                                  
                IQueryable<SchoolClass> result = from schoolClassSubjects in _repositoryManager.SchoolClassSubjectsRepo.FindAll()
                                                 where schoolClassSubjects.SubjectId == subjectId
                                                 select schoolClassSubjects.SchoolClass;
                return result;
            }
            return new Collection<SchoolClass>().AsQueryable();
        }
    }
}
