using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;

namespace FSD_NET_WebApplication.Repository.Data;

public class EducationsRepository : GeneralRepository<MyContext, Educations, int>, IEducationsRepository
{
    public EducationsRepository(MyContext myContext) : base(myContext)
    {

    }
}