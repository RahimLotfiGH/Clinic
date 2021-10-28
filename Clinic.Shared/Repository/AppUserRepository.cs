using Clinic.Application.Contracts;
using Clinic.Data.Contexts;
using Clinic.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Clinic.Shared.Repository
{
    public class AppUserRepository : RepositoryBase<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateAppUser(AppUser appUser)
        {
            Create(appUser);
        }

        public void DeleteAppUser(AppUser appUser)
        {
            Delete(appUser);
        }

        public IEnumerable<AppUser> GetAllAppUsers()
        {
            return FindAll()
                   .OrderBy(a => a.FirstName)
                   .ToList();
        }

        public AppUser GetAppUserById(long id)
        {
            return FindByCondition(u => u.Id.Equals(id)).FirstOrDefault();
        }

        public void UpdateAppUser(AppUser appUser)
        {
            Update(appUser);
        }
    }
}
