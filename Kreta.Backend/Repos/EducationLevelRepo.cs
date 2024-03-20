using Kreta.Backend.Context;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class EducationLevelRepo<TDbContext> : RepositoryBase<TDbContext, EducationLevel>, IEducationLevelRepo
        where TDbContext : KretaContext
    {
        public EducationLevelRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
