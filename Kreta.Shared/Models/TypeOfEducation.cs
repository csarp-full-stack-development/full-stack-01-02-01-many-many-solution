
namespace Kreta.Shared.Models
{
    public class TypeOfEducation : IDbEntity<TypeOfEducation>
    {
        public Guid Id { get; set; }

        public bool HasId => Id != Guid.Empty;
        
        public string EducationName { get; set; } = string.Empty;
    }
}
