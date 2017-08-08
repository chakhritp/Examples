using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI_Basic.Controllers
{
    public class CarController : Controller
    {
        //
        // GET: /Car/

        public ActionResult Car()
        {
            return View("CarStock");
        }

    }
}
