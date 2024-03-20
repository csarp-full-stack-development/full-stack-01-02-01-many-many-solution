using Kreta.Backend.Context;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Backend.Repos
{
    public class TeacherRepo<TDbContext> : RepositoryBase<TDbContext, Teacher>, ITeacherRepo
        where TDbContext : KretaContext
    {
    }
}
