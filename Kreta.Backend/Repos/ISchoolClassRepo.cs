﻿using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public interface ISchoolClassRepo : IRepositoryBase<SchoolClass>
    {
        public IQueryable<SchoolClass> SelectSchoolClassesWithSubjects();
    }
}
