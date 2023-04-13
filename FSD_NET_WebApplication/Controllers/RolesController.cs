using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FSD_NET_WebApplication.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _rolesRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entities = _rolesRepository.GetByKey(id);
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
        public IActionResult Create(Roles roles)
        {
            _rolesRepository.Insert(roles);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entities = _rolesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Roles roles)
        {
            _rolesRepository.Update(roles);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entities = _rolesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _rolesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
