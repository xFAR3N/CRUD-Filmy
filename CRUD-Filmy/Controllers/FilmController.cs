using CRUD_Filmy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Filmy.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> filmy = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis1", Price = 3},
            new Film(){Id = 2, Name = "Film2", Description = "opis2", Price = 5},
            new Film(){Id = 3, Name = "Film3", Description = "opis3", Price = 8},
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(filmy);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(filmy.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = filmy.Count + 1;
            filmy.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(filmy.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film filmd = filmy.FirstOrDefault(x => x.Id == id);
            film.Name = film.Name;
            film.Description = film.Description;
            film.Price = film.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Film film = filmy.FirstOrDefault(x => x.Id == id);
            filmy.Remove(film);
            return RedirectToAction(nameof(Index));
        }
    }
}
