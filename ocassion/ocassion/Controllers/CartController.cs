using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ocassion.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult CheckOut()
        {
            return View();
        }

    }
}
