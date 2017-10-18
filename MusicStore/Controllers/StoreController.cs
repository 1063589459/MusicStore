using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            //var genres = new List<Genre>
            //{
            //    new Genre { Name = "Disco" },
            //    new Genre { Name = "Jazz" },
            //    new Genre { Name = "Rock" }
            //};
            //return View(genres);
            var genres = storeDB.Genres.ToList();
            return this.View(genres);
        }

        public ActionResult Browse(string genre)
        {
            //var genreModel = new Genre { Name = genre };
            //return View(genreModel);
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            //var album = new Album { Title = "Album " + id };
            //return View(album);
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

    }
}
