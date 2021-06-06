using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMusicStoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicStoreTutorial.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(MusicStoreEntities musicStoreEntities )
        {
            // var onealbum = musicStoreEntities.Albums.FirstOrDefault();

            // var oneaar = musicStoreEntities.Artists.FirstOrDefault();

            //// var oneger = musicStoreEntities.Genres.FirstOrDefault();

            var xd = musicStoreEntities.Albums.FirstOrDefault();


           // Console.WriteLine(onealbum.Artist.Name);

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
