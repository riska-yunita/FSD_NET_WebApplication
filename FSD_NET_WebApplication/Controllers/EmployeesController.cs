using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FSD_NET_WebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _employeesRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var entities = _employeesRepository.GetByKey(id);
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
        public IActionResult Create(Employees employees)
        {
            _employeesRepository.Insert(employees);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var entities = _employeesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees employees)
        {
            _employeesRepository.Update(employees);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var entities = _employeesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string id)
        {
            _employeesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
