using Kreta.Backend.Context;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class TypeOfEducationRepo<TDbContext> : RepositoryBase<TDbContext, TypeOfEducation>, ITypeOfEducationRepo
        where TDbContext : KretaContext
    {
    }
}
