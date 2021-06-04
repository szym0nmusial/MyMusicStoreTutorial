using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MyMusicStoreTutorial.Models;

namespace MyMusicStoreTutorial.Controllers
{
    public class StoreController : Controller
    {
        IEnumerable<Genre> genres;
        public StoreController()
        {
            genres = new List<Genre>
            {
                new Genre { Name = "Disco"},
                new Genre { Name = "Jazz"},
                new Genre { Name = "Rock"}
            };
        }
        /// <summary>
        /// GET: /Store/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(genres);
        }

        /// <summary>
        /// /Store/Browse?genre=Disco
        /// </summary>
        /// <param name="genre">Argument GET-a</param>
        /// <returns></returns>
        public ActionResult Browse(string genre)
        {
            return View(new Genre { Name = genre });
        }


    /// <summary>
    /// GET: /Store/Details/id
    /// </summary>
    /// <returns></returns>
    public ActionResult Details(int id)
        {
             return View(new Album { Title = "Album " + id });
        }
    }
}
