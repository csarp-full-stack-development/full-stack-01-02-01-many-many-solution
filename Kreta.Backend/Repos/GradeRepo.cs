using Kreta.Backend.Context;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class GradeRepo<TDbContext> : RepositoryBase<TDbContext, Grade>, IGradeRepo
        where TDbContext : KretaContext
    {        
    }
}
