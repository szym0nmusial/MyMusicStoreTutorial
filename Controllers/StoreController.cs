using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyMusicStoreTutorial.Controllers
{
    public class StoreController : Controller
    {
        /// <summary>
        /// GET: /Store/
        /// </summary>
        /// <returns></returns>
        public string Index()
        {
            return "Hello from Store.Index()";
        }
        ///// <summary>
        ///// GET: /Store/Browse
        ///// </summary>
        ///// <returns></returns>
        //public string Browse()
        //{
        //    return "Hello from Store.Browse()";
        //}

        /// <summary>
        /// /Store/Browse?genre=Disco
        /// </summary>
        /// <param name="genre">Argument GET-a</param>
        /// <returns></returns>
        public string Browse(string genre)
        {
            return HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
        }


        /// <summary>
        /// GET: /Store/Details/id
        /// </summary>
        /// <returns></returns>
        public string Details(int id)
        {
            return "Store.Details, ID = " + id;
        }
    }
}
