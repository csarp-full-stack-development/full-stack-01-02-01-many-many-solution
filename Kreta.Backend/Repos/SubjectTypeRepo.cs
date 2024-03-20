using Kreta.Backend.Context;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class SubjectTypeRepo<TDbContext> : RepositoryBase<TDbContext, SubjectType>, ISubjectType
        where TDbContext : KretaContext
    {
    }
}
