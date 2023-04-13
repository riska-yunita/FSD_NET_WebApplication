using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;

namespace FSD_NET_WebApplication.Repository.Data;

public class EmployeesRepository : GeneralRepository<MyContext, Employees, string>, IEmployeesRepository
{
    public EmployeesRepository(MyContext myContext) : base(myContext)
    {

    }
}
