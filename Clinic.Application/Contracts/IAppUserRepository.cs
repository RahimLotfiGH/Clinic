using Clinic.Domain.Entities;
using System.Collections.Generic;

namespace Clinic.Application.Contracts
{
    public interface IAppUserRepository : IRepositoryBase<AppUser>
    {
        IEnumerable<AppUser> GetAllAppUsers();
        AppUser GetAppUserById(long id);
        void CreateAppUser(AppUser appUser);
        void UpdateAppUser(AppUser appUser);
        void DeleteAppUser(AppUser appUser);
    }
}
