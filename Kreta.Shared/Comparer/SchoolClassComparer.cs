using Kreta.Shared.Models;
using System.Diagnostics.CodeAnalysis;

namespace Kreta.Shared.Comparer
{
    public class SchoolClassComparer : IEqualityComparer<SchoolClass>
    {
        public bool Equals(SchoolClass? schoolClass1, SchoolClass? schoolClass2)
        {
            if (schoolClass1 is not null && schoolClass2 is not null)
            {
                if (schoolClass1.Id == schoolClass2.Id && schoolClass1.SchoolClassName.ToLower()==schoolClass2.SchoolClassName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public int GetHashCode([DisallowNull] SchoolClass obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
