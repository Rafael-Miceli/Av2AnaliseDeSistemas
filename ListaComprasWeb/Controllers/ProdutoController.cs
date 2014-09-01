using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaComprasWeb.Controllers
{
    public class ProdutoController : Controller
    {
       
        //
        // GET: /Produto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index", "ListaDeCompras");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produto/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Produto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produto/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Produto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}
