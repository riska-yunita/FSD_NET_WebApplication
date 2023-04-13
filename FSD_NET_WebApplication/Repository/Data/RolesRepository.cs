using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;

namespace FSD_NET_WebApplication.Repository.Data;

public class RolesRepository : GeneralRepository<MyContext, Roles, int>, IRolesRepository
{
    public RolesRepository(MyContext myContext) : base(myContext)
    {

    }
}