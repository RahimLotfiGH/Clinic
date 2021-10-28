namespace Clinic.Application.Contracts
{
    public interface IRepositoryWrapper
    {
        IAppUserRepository AppUser { get; }
        void Save();
    }
}
