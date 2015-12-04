using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayoffBracket.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Player_Post(string amountOfPlayers, List<string> playerNames)
        {
            if (amountOfPlayers == null)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}