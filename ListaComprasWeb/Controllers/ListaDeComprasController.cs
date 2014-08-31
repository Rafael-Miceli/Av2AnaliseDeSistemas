using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;
using ListaComprasWeb.Models;
using ListaDeCompras.Dal;

namespace ListaComprasWeb.Controllers
{
    public class ListaDeComprasController : Controller
    {
        private readonly IListaDeProdutos _listaDeProdutos;

        public ListaDeComprasController() : this(new ListaDeProdutos(ProdutoRepository.Create(), ItemDeProdutoRepository.Create()))
        {}

        public ListaDeComprasController(IListaDeProdutos listaDeProdutos)
        {
            _listaDeProdutos = listaDeProdutos;
        }

        //
        // GET: /ListaDeCompras/

        public ActionResult Index()
        {
            return View(RetorneListaDeCompras());
        }


        //O Correto seria está área permanecer em um project de Mapeamento
        private ProdutoItemViewModel RetorneListaDeCompras()
        {
            return new ProdutoItemViewModel
            {
                ItemDeProdutos = _listaDeProdutos.MontarListaDeCompras()
            };
        }

    }
}
