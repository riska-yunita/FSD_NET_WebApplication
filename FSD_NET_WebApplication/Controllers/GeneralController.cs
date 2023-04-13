using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FSD_NET_WebApplication.Controllers
{
    public class GeneralController<Entity, Repository, Key> : Controller
        where Entity : class
        where Repository : IGeneralRepository<Entity, Key>
    {
        private readonly Repository repository;

        public GeneralController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = repository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(Key id)
        {
            var entities = repository.GetByKey(id);
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
        public IActionResult Create(Entity entity)
        {
            repository.Insert(entity);
            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        public IActionResult Edit(Key id)
        {
            var entities = repository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Entity entity)
        {
            repository.Update(entity);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpGet]
        public IActionResult Delete(Key id)
        {
            var entities = repository.GetByKey(id);
            return View(entities);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(Key id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
