using Kreta.Backend.Repos.SwitchTables;

namespace Kreta.Backend.Repos.Managers
{
    public interface IRepositoryManager
    {
        public ISchoolClassRepo? SchoolClassRepo { get; }
        public ISubjectRepo? SubjectRepo { get; }
        public ISchoolClassSubjectsRepo? SchoolClassSubjectsRepo { get; }
    }
}
