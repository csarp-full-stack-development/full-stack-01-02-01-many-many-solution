
using Kreta.Shared.Models;

namespace Kreta.Shared.Parameters
{
    public class SchoolClassSubjectsIdParameters
    {
        public Guid Id { get; set; }
        public Guid SchoolClassId { get; set; }
        public Guid SubjectId { get; set; }

        public bool HasId => Id!=Guid.Empty;
        public bool HasSchoolClassId  => SchoolClassId!=Guid.Empty;
        public bool HasSubjectId => SubjectId!=Guid.Empty;
    }
}
