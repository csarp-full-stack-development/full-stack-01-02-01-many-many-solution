using Kreta.Backend.Context;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class AddressRepo<TDbContext> : RepositoryBase<TDbContext, Address>, IAddressRepo
        where TDbContext : KretaContext
    {
    }
}
