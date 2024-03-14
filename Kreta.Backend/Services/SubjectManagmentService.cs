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
        public IQueryable<SchoolClass> SelectSchoolClassWhoNotStudiedSubject(Guid subjectId)
        {
            if (_repositoryManager is not null && _repositoryManager.SchoolClassSubjectsRepo is not null && _repositoryManager.SchoolClassRepo is not null)
            {

                try
                {
                    IQueryable<SchoolClass> schoolClassWhoNotStudiedSubject =
                        from schoolClassSubjects in _repositoryManager.SchoolClassSubjectsRepo.FindAll()
                        where schoolClassSubjects.SubjectId == subjectId
                        select schoolClassSubjects.SchoolClass;

                    List<SchoolClass> h1 = schoolClassWhoNotStudiedSubject.ToList();
                    List<SchoolClass> h2 = _repositoryManager.SchoolClassRepo.FindAll().ToList();

                    IQueryable<SchoolClass> result = _repositoryManager
                        .SchoolClassRepo
                        .FindAll()
                        .Except(schoolClassWhoNotStudiedSubject, new SchoolClassComparer());

                    //List<SchoolClass> except = result.ToList();

                    var result2 = _repositoryManager
                        .SchoolClassRepo
                        .FindAll()
                        .Where(schoolClass => schoolClassWhoNotStudiedSubject.All(schoolClass2 => schoolClass2.Id != schoolClass.Id));
                    List<SchoolClass> except = result2.ToList();

                    return result2;


                    /*return _repositoryManager
                        .SchoolClassRepo
                        .FindAll()
                        .Except(schoolClassWhoNotStudiedSubject, new SchoolClassComparer());*/


                   

                    //return schoolClassWhoNotStudiedSubject;
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
