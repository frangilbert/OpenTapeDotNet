using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenTapeDotNet.Controllers
{
    public class InitController : Controller
    {
        //
        // GET: /Init/

        public JsonResult Ajax()
        {
            return new JsonResult();
        }

        public ActionResult SetPassword()
        {
            return View();
        }
    }
}
