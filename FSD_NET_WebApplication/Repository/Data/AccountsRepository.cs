using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using FSD_NET_WebApplication.ViewModel;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace FSD_NET_WebApplication.Repository.Data;

public class AccountsRepository : GeneralRepository<MyContext, Accounts, string >, IAccountsRepository
{
    private readonly MyContext context;
    public AccountsRepository(MyContext myContext) : base(myContext)
    {
        context = myContext;
    }
    public RegisterVM? Register(RegisterVM register)
    {
        //Validasi untuk input entitas jika gagal lakukan rollback
        //validasi apakah input university name ada di db atau tidak
        var transaction =_context.Database.BeginTransaction();

        try
        {
            var universities = _context.Set<Universities>().FirstOrDefault(
                u => u.Name.Equals(register.UniversityName));

            if(universities is null)
            {
                universities = new Universities
                {
                    Name = register.UniversityName
                };
                _context.TB_M_Universities.Add(universities);
                _context.SaveChanges();
            }
            var education = new Educations
            {
                Major = register.Major,
                Degree = register.Degree,
                GPA = register.GPA,
                UniversityId = universities.Id
            };
            _context.TB_M_Educations.Add(education);
            _context.SaveChanges();

            var employee = new Employees
            {
                NIK = register.NIK,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Birthdate = register.Birthdate,
                Gender = register.Gender,
                PhoneNumber = register.PhoneNumber,
                Email = register.Email,
                HiringDate = DateTime.Now,
            };
            _context.TB_M_Employees.Add(employee);
            _context.SaveChanges();

            _context.TB_M_Accounts.Add(new Accounts
            {
                EmployeeNIK = employee.NIK,
                Password = register.Password,
            });

            _context.TB_TR_Account_Roles.Add(new AccountRoles
            {
                AccountNIK = employee.NIK,
                RoleId = 2
            });

            var profiling = new Profilings
            {
                EmployeeNIK = register.NIK,
                EducationId = education.Id
            };
            _context.TB_TR_Profiling.Add(profiling);
            _context.SaveChanges();

            transaction.Commit();
        }
        catch(Exception)
        {
            transaction.Rollback();
            throw;
        }
        return register;
    }
 

    private bool CheckUniversities(string name)
    {
       return _context.TB_M_Universities.Where(s=>s.Name==name).SingleOrDefault() == null;
    }

    public int Login(LoginVM login)
    {
        var checkLogin = context.TB_M_Employees
            .Join(context.TB_M_Accounts, e => e.NIK, a => a.EmployeeNIK,
            (e, a) => new
            {
                Email = e.Email,
                Password = a.Password
            }).SingleOrDefault(e=>e.Email == login.Email);
        if (checkLogin != null)
        {
            return 1;
        }
        return 0;
    }
}