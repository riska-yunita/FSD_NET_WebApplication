using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FSD_NET_WebApplication.Controllers
{
    public class ProfilingsController : Controller
    {
        private readonly IProfilingsRepository _profilingsRepository;
        private readonly MyContext context;
        public ProfilingsController(IProfilingsRepository profilingsRepository)
        {
            _profilingsRepository = profilingsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _profilingsRepository.GetAll();
            return View(entities);
        }
       
        [HttpGet]
        public IActionResult Details(string id)
        {
            var entities = _profilingsRepository.GetByKey(id);
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
        public IActionResult Create(Profilings profilings)
        {
            _profilingsRepository.Insert(profilings);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var entities = _profilingsRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Profilings profilings)
        {
            _profilingsRepository.Update(profilings);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var entities = _profilingsRepository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string id)
        {
            _profilingsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
