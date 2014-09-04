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
        private readonly ProdutoServiceTemplate _produtoServiceTemplate;


        public ProdutoController(IProdutoRepository produtoRepository, ProdutoServiceTemplate produtoServiceTemplate)
        {
            _produtoRepository = produtoRepository;
            _produtoServiceTemplate = produtoServiceTemplate;
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
                _produtoServiceTemplate.Criar(produto);

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
            return View(Produto.CarregarProduto(id, _produtoRepository));
        }

        //
        // POST: /Produto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Produto produto, string submitButton)
        {
            try
            {
                if (submitButton == "Deletar")
                    DeletarProduto(produto);
                else
                    EditarProduto(produto);

                return RedirectToAction("ListaDeProdutos", "ListaDeCompras");
            }
            catch
            {
                return View();
            }
        }

        private void DeletarProduto(Produto produto)
        {
            _produtoServiceTemplate.Deletar(produto);
        }

        private void EditarProduto(Produto produto)
        {
            _produtoServiceTemplate.Editar(produto);
        }
    }
}
