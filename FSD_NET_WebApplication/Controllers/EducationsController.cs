using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using FSD_NET_WebApplication.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FSD_NET_WebApplication.Controllers
{
    public class EducationsController : Controller
    {
        private readonly IEducationsRepository _educationsRepository;
        private readonly IUniversitiesRepository _universitiesRepository;
        public EducationsController(IEducationsRepository educationsRepository, IUniversitiesRepository universitiesRepository)
        {
            _educationsRepository = educationsRepository;
            _universitiesRepository = universitiesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _educationsRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entities = _educationsRepository.GetByKey(id);
            return View(entities);
        }

        //INSERT
        [HttpGet]
        public IActionResult Create()
        {
            var universities = _universitiesRepository.GetAll();
            var selectListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.UniversitiesId = selectListUniversities;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Educations educations)
        {
            _educationsRepository.Insert(educations);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entities = _educationsRepository.GetByKey(id);
            var universities = _universitiesRepository.GetAll();
            var selectListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.UniversitiesId = selectListUniversities;

            return View(entities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Educations educations)
        {
            _educationsRepository.Update(educations);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entities = _educationsRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _educationsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
