using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcWeb.Controllers
{
    /// <summary>
    /// This class is the home controller 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/
        /// </summary>
        /// <returns>This is bullshit dsfsds</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
