using Kreta.Backend.Repos.Managers;
using Kreta.Shared.Models;
using Kreta.Shared.Models.SwitchTable;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Services
{
    public class SchoolClassManagmentService : ISchoolClassManagmentService
    {
        private readonly IRepositoryManager? _repositoryManager;
        public SchoolClassManagmentService(IRepositoryManager? repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public IQueryable<Subject> SelectSubjectNoStudiedInTheSchoolClass(Guid schoolClassId)
        {
            if (_repositoryManager is not null && _repositoryManager.SchoolClassSubjectsRepo is not null && _repositoryManager.SubjectRepo is not null)
            {
                IQueryable<Subject?> subjectStudiedInTheSchoolClass =
                    _repositoryManager
                    .SchoolClassSubjectsRepo
                    .FindAll()
                    .Where(schoolClassSubjects => schoolClassSubjects.SchoolClassId == schoolClassId)
                    .Select(schoolClassSubjects => schoolClassSubjects.Subject);

                IQueryable<Subject> result =
                    _repositoryManager
                    .SubjectRepo
                    .FindAll()
                    .Where(subject => subjectStudiedInTheSchoolClass.All(studiedInTheClass => studiedInTheClass!=null &&  studiedInTheClass.Id!=subject.Id));
                return result;
            }
            return Enumerable.Empty<Subject>().AsQueryable().AsNoTracking();
        
        }
    }
}
