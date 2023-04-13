using FSD_NET_WebApplication.Repository.Contracts;
using FSD_NET_WebApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FSD_NET_WebApplication.Controllers;

public class AccountsController : Controller 
{ 
    private readonly IAccountsRepository _accountsRepository;
    private readonly IUniversitiesRepository _universitiesRepository;
    public AccountsController(IAccountsRepository accountsRepository, IUniversitiesRepository universitiesRepository)
    {
        _accountsRepository = accountsRepository;
        _universitiesRepository = universitiesRepository;
    }

    //GET - Register
    public IActionResult Register()
    {
        var gender = new List<SelectListItem>()
        {
            new SelectListItem
            {
                Text="Male",
                Value="0"
            },
            new SelectListItem
            {
                Text ="Female",
                Value="1"
            }
        };
        ViewBag.Gender = gender;

        return View();
    }

    //POST- register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register (RegisterVM register)
    {
       var result = _accountsRepository.Register(register);
       if (register is not null)
       {
            return RedirectToAction("Login", "Accounts");
       }   
       return View();
    }

    //GET - Login
    public IActionResult Login()
    {
        return View();
    }

    //POST- register
    [HttpPost]
    public IActionResult Login(LoginVM login)
    {
        var result = _accountsRepository.Login(login);
        if (result > 0)
        {
            return RedirectToAction("Index", "Accounts");
        }
        return View(login);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var entities = _accountsRepository.GetAll();
        return View(entities);
    }
    [HttpGet]
    public IActionResult Details(string id)
    {
        var entities = _accountsRepository.GetByKey(id);
        return View(entities);
    }

    //DELETE
    [HttpGet]
    public IActionResult Delete(string id)
    {
        var entities = _accountsRepository.GetByKey(id);
        return View(entities);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(string id)
    {
        _accountsRepository.Delete(id);
        return RedirectToAction("Index");
    }
}
