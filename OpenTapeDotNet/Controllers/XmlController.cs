using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenTapeDotNet.Controllers
{
    public class XmlController : Controller
    {
        public ContentResult Index()
        {
            return Content("", "application/xspf+xml", System.Text.Encoding.UTF8);
        }

    }
}
