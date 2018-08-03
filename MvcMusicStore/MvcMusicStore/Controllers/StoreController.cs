using MvcMusicStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly DefaultDataContext db = new DefaultDataContext();
        // GET: Store
        public ActionResult Index()
        {
            var listOfGenres = db.Genres.ToList();
            return View(listOfGenres);
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = db.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);
            return View(album);
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = db.Genres.ToList();
            return PartialView(genres);
        }
    }
}