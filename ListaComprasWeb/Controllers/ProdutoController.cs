using System.Web.Mvc;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;
using ListaCompras.Domain.Service;
using ListaDeCompras.Dal;

namespace ListaComprasWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IItemDeProdutoRepository _itemDeProdutoRepository;


        public ProdutoController(IProdutoRepository produtoRepository, IItemDeProdutoRepository itemDeProdutoRepository)
        {
            _produtoRepository = produtoRepository;
            _itemDeProdutoRepository = itemDeProdutoRepository;
        }

        //
        // GET: /Produto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        public ActionResult Create(Produto produtoForm)
        {
            try
            {
                var produto = new Produto(produtoForm.Nome, produtoForm.QuantidadeMinima, produtoForm.Unidade);
                ProdutoServiceTemplate produtoService = new ProdutoService(_produtoRepository, _itemDeProdutoRepository);
                produtoService.Criar(produto);

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
