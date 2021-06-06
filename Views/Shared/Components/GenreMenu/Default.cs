using Microsoft.AspNetCore.Mvc;
using MyMusicStoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicStoreTutorial
{
    public class GenreMenuViewComponent : ViewComponent
    {
        MusicStoreEntities storeDB;
        public GenreMenuViewComponent(MusicStoreEntities musicStoreEntities)
        {
            storeDB = musicStoreEntities;
        }
        public IViewComponentResult Invoke()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
    }
}
