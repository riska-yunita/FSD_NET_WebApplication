using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.ViewModel;

namespace FSD_NET_WebApplication.Repository.Contracts;

public interface IAccountsRepository : IGeneralRepository<Accounts, string>
{
    RegisterVM? Register(RegisterVM register);
    int Login(LoginVM login);
}
