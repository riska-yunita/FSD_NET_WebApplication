using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FSD_NET_WebApplication.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly IUniversitiesRepository _universitiesRepository;
        public UniversitiesController(IUniversitiesRepository universitiesRepository)
        {
            _universitiesRepository = universitiesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _universitiesRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entities = _universitiesRepository.GetByKey(id);
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
        public IActionResult Create(Universities universities)
        {
            _universitiesRepository.Insert(universities);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entities = _universitiesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Universities universities)
        {
            _universitiesRepository.Update(universities);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entities = _universitiesRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _universitiesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
