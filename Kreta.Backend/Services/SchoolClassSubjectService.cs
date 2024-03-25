using Kreta.Backend.Repos.Managers;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Kreta.Backend.Services
{
    public class SchoolClassSubjectService : ISchoolClassSubjectService
    {
        private readonly IRepositoryManager? _repositoryManager;
        public SchoolClassSubjectService(IRepositoryManager? repositoryManager)
        {
            repositoryManager = _repositoryManager;
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
                    .Where(subject => subjectStudiedInTheSchoolClass.All(studiedInTheClass => studiedInTheClass != null && studiedInTheClass.Id != subject.Id));
                return result;
            }
            return Enumerable.Empty<Subject>().AsQueryable().AsNoTracking();
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

        public Task MoveSubjectToNotStudiedInTheSchoolClass(Guid subjectId, Guid schoolClassId)
        {
            return Task.CompletedTask;
        }
    }
}
