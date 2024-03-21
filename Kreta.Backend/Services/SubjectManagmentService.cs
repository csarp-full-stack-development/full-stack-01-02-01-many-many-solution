using Kreta.Backend.Repos.Managers;
using Kreta.Shared.Comparer;
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
        public IQueryable<SchoolClass> SelectSchoolClassWhoNotStudyingSubject(Guid subjectId)
        {
            if (_repositoryManager is not null && _repositoryManager.SchoolClassSubjectsRepo is not null && _repositoryManager.SchoolClassRepo is not null)
            {

                try
                {
                    IQueryable<SchoolClass> schoolClassWhoStudySubject =
                        from schoolClassSubjects in _repositoryManager.SchoolClassSubjectsRepo.FindAll()
                        where schoolClassSubjects.SubjectId == subjectId
                        select schoolClassSubjects.SchoolClass;


                    var result = _repositoryManager
                         .SchoolClassRepo
                         .FindAll()
                         .Where(subject => schoolClassWhoStudySubject.All(whoStudy => whoStudy.Id != subject.Id));

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new Collection<SchoolClass>().AsQueryable();
        }
    }
}
