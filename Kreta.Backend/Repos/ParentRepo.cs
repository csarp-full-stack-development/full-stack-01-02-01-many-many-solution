using Kreta.Backend.Context;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Backend.Repos
{
    public class ParentRepo<TDbContext> : RepositoryBase<TDbContext, Parent>, IParentRepo
        where TDbContext : KretaContext
    {
        public ParentRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
