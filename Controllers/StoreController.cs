using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MyMusicStoreTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace MyMusicStoreTutorial.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        /// <summary>
        /// GET: /Store/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        /// <summary>
        /// /Store/Browse?genre=Disco
        /// </summary>
        /// <param name="genre">Argument GET-a</param>
        /// <returns></returns>
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums")
             .Single(g => g.Name == genre);
            return View(genreModel);
        }


    /// <summary>
    /// GET: /Store/Details/id
    /// </summary>
    /// <returns></returns>
    public ActionResult Details(int id)
        {
            //var musicStoreEntities = storeDB.Albums.Include(a => a.Artist).Include(a => a.Genre).Where(a => a.AlbumId == id);

            //var aa = storeDB.Albums.Find(id).Include(a => a.Genre);

            var musicStoreEntities = storeDB.Albums.Include(a => a.Artist).Include(a => a.Genre).FirstOrDefault(a => a.AlbumId == id);



            return View(musicStoreEntities);
        }
    }
}
