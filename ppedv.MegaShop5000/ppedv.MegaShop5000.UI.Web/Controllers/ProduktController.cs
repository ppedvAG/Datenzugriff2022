using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.MegaShop5000.Model;
using ppedv.MegaShop5000.Model.Contracts;

namespace ppedv.MegaShop5000.UI.Web.Controllers
{
    public class ProduktController : Controller
    {
        private readonly IRepository repo;
        public ProduktController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: ProduktController
        public ActionResult Index()
        {
            return View(repo.Query<Produkt>().OrderBy(x => x.Name));
        }

        // GET: ProduktController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById<Produkt>(id));
        }

        // GET: ProduktController/Create
        public ActionResult Create()
        {
            return View(new Produkt() { Name = "NEU", Gewicht = 999 });
        }

        // POST: ProduktController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produkt p)
        {
            try
            {
                repo.Add(p);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduktController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById<Produkt>(id));
        }

        // POST: ProduktController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produkt p)
        {
            try
            {
                repo.Update(p);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduktController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById<Produkt>(id));
        }

        // POST: ProduktController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produkt p)
        {
            try
            {
                repo.Delete(p);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
