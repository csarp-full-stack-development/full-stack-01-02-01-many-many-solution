using Kreta.Backend.Context;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class PublicSpaceRepo<TDbContext> : RepositoryBase<TDbContext, PublicSpace>, IPublicSpaceRepo
        where TDbContext : KretaContext
    {
    }
}
