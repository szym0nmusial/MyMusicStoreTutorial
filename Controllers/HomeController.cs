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
        MusicStoreEntities storeDB;
        public HomeController(MusicStoreEntities musicStoreEntities )
        {
            storeDB = musicStoreEntities;
        }
        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }
        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Albums
            .OrderByDescending(a => a.OrderDetails.Count())
            .Take(count)
            .ToList();
        }
    }
}
