using Kreta.Shared.Dtos;
using Kreta.Shared.Models;

namespace Kreta.Shared.Extensions
{
    public static class SchoolClassSubjectsExtension
    {
        public static SchoolClassSubjects ToModel(this SchoolClassSubjectsDto subject)
        {
            return new SchoolClassSubjects
            {
                Id= subject.Id,
                SchoolClassId = subject.SchoolClassId,
                SubjectId = subject.SubjectId,
                NumberOfHours = subject.NumberOfHours,
                TheHoursInOne= subject.TheHoursInOne,
            };
        }

        public static SchoolClassSubjectsDto ToDto(this SchoolClassSubjects subject)
        {
            return new SchoolClassSubjectsDto
            {
                Id = subject.Id,
                SchoolClassId = subject.SchoolClassId,
                SubjectId = subject.SubjectId,
                NumberOfHours = subject.NumberOfHours,
                TheHoursInOne = subject.TheHoursInOne,
            };
        }
    }
}
