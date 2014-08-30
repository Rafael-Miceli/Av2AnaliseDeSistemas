using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaComprasWeb.Controllers
{
    public class ListaDeComprasController : Controller
    {
        //
        // GET: /ListaDeCompras/

        public ActionResult Index()
        {
            return View(RetorneListaDeCompras());
        }

        private IView RetorneListaDeCompras()
        {
            throw new NotImplementedException();
        }

    }
}
