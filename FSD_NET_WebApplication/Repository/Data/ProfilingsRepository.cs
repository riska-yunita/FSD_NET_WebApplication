using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;

namespace FSD_NET_WebApplication.Repository.Data;

public class ProfilingsRepository : GeneralRepository<MyContext, Profilings, string>, IProfilingsRepository
{
    public ProfilingsRepository(MyContext myContext) : base(myContext)
    {

    }
}