using Clinic.Application.Contracts;
using Clinic.Data.Contexts;

namespace Clinic.Shared.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IAppUserRepository _appUser;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAppUserRepository AppUser
        {
            get
            {
                if (_appUser == null)
                {
                    _appUser = new AppUserRepository(_context);
                }
                return _appUser;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
