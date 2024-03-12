namespace Kreta.Backend.Repos.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private ISchoolClassRepo? _schooolClassRepo;       
        private ISubjectRepo? _subjectRepo;
        private ISchoolClassSubjectsRepo? _schoolClassSubjectsRepo;


        public RepositoryManager(ISchoolClassRepo schoolClassRepo,
            ISubjectRepo subjectRepo,
            ISchoolClassSubjectsRepo schoolClassSubjectsRepo

            )
        {
            _schooolClassRepo = schoolClassRepo;
            _subjectRepo = subjectRepo;
            _schoolClassSubjectsRepo = schoolClassSubjectsRepo;
        }

        public ISchoolClassRepo? SchoolClassRepo => _schooolClassRepo;
        public ISubjectRepo? SubjectRepo => _subjectRepo;
        public ISchoolClassSubjectsRepo? SchoolClassSubjectsRepo => _schoolClassSubjectsRepo;
    }
}
