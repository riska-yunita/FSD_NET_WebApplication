using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;

namespace FSD_NET_WebApplication.Repository.Data;

public class AccountsRolesRepository : GeneralRepository<MyContext, AccountRoles, int>, IAccountRolesRepository
{
    public AccountsRolesRepository(MyContext myContext) : base(myContext)
    {

    }
}