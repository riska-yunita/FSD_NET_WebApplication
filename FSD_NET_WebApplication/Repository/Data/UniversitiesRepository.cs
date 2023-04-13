using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;

namespace FSD_NET_WebApplication.Repository.Data;

public class UniversitiesRepository:GeneralRepository<MyContext, Universities, int>, IUniversitiesRepository
{
    public UniversitiesRepository(MyContext myContext) : base(myContext)
    {

    }
}
