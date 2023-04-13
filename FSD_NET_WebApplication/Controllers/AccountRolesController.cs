using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FSD_NET_WebApplication.Controllers
{
    public class AccountRolesController : Controller
    {
        private readonly IAccountRolesRepository _accountRolesRepository;
        public AccountRolesController(IAccountRolesRepository accountRolesRepository)
        {
            _accountRolesRepository = accountRolesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _accountRolesRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entities = _accountRolesRepository.GetByKey(id);
            return View(entities);
        }

        //INSERT
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountRoles accountRoles)
        {
            _accountRolesRepository.Insert(accountRoles);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entities = _accountRolesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountRoles accountRoles)
        {
            _accountRolesRepository.Update(accountRoles);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entities = _accountRolesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _accountRolesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
