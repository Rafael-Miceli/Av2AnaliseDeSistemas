using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;
using ListaDeCompras.Dal;

namespace ListaComprasWeb.Controllers.Api
{
    public class ListaDeProdutosController : ApiController
    {
        private readonly IListaDeProdutos _listaDeProdutos;

        public ListaDeProdutosController() : this(new ListaDeProdutos(ProdutoRepository.Create(), ItemDeProdutoRepository.Create()))
        {}

        public ListaDeProdutosController(IListaDeProdutos listaDeProdutos)
        {
            _listaDeProdutos = listaDeProdutos;
        }


        // GET api/listadeprodutos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/listadeprodutos
        public void Post([FromBody]string value)
        {
        }

        // PUT api/listadeprodutos/5
        public string AdicionarItemDeProduto(int produtoId)
        {
           var itemDeProdutoId = _listaDeProdutos.AdcionarItem(produtoId);
            return itemDeProdutoId.ToString();
        }

        // DELETE api/listadeprodutos/5
        public void Delete(int itemDeProdutoId, int produtoId)
        {
            _listaDeProdutos.RemoverItem(itemDeProdutoId);
        }
    }
}
