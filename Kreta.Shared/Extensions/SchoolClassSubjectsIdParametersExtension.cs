using Kreta.Shared.Dtos;
using Kreta.Shared.Parameters;

namespace Kreta.Shared.Extensions
{
    public static class SchoolClassSubjectsIdParametersExtension
    {
        public static SchoolClassSubjectsIdParametersDto ToDto(this SchoolClassSubjectsIdParameters parameters)
        {
            return new SchoolClassSubjectsIdParametersDto
            {
                SubjectId = parameters.SubjectId,
                SchoolClassId = parameters.SchoolClassId,
                Id = parameters.Id,
            };
        }
        public static SchoolClassSubjectsIdParameters ToModel(this SchoolClassSubjectsIdParametersDto dto)
        {
            return new SchoolClassSubjectsIdParameters
            {
                SubjectId = dto.SubjectId,
                SchoolClassId = dto.SchoolClassId,
                Id = dto.Id,
            };
        }
    }
}
