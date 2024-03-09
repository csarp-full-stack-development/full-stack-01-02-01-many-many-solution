using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Repos
{
    public class TypeOfEducationRepo<TDbContext> : RepositoryBase<TDbContext, TypeOfEducation>, ITypeOfEducationRepo
        where TDbContext : DbContext
    {
        public TypeOfEducationRepo(IDbContextFactory<TDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
