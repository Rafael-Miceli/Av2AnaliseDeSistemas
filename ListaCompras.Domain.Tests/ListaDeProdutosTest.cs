using System;
using System.Linq;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;
using ListaDeCompras.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListaCompras.Domain.Tests
{
    [TestClass]
    public class ListaDeProdutosTest
    {
        private IListaDeProdutos _listaDeProdutos;

        [TestInitialize]
        public void Initialize()
        {
            var produtoRepository = ProdutoRepository.Create();
            produtoRepository.CriarDummies();

            var itemDeProdutoRepository = ItemDeProdutoRepository.Create();
            itemDeProdutoRepository.CriarDummies(produtoRepository.RetornarProdutos());

            _listaDeProdutos = new ListaDeProdutos(ProdutoRepository.Create(), ItemDeProdutoRepository.Create());
        }

        [TestMethod]
        [Ignore]
        public void Given_A_Product_When_Adding_The_First_Item_Then_Create_Id_1()
        {
            var produtoRepository = ProdutoRepository.Create();
            produtoRepository.CriarDummies();

            Assert.AreEqual(1, produtoRepository.RetornarProdutos().Find(p => p.Id == 1).Id);
        }

        [TestMethod]
        [Ignore]
        public void Given_A_ItemDeProduto_When_Adding_The_First_Item_Then_Create_Id_1()
        {
            var produtoRepository = ItemDeProdutoRepository.Create();
            produtoRepository.CriarDummies(ProdutoRepository.Create().RetornarProdutos());

            Assert.AreEqual(1, produtoRepository.Listar().Find(p => p.Id == 1).Id);
        }

        [TestMethod]
        public void When_Request_MontarListaDeCompras_Then_Return_List_Of_ItemDeProduto_With_Produtos_Below_QuantidadeMinima()
        {
            var listaDeCompras = _listaDeProdutos.MontarListaDeCompras();

            Assert.IsNotNull(listaDeCompras);
            Assert.IsTrue(listaDeCompras.Count > 0);
        }

        [TestMethod]
        public void Given_A_Valid_Product_When_Adding_To_Memory_Then_Add_Also_The_ListaDeProdutos()
        {
            var produto = new Produto("Beterraba", 1, "Kg");
            var produtoRepository = ProdutoRepository.Create();
            produtoRepository.AdicionarProduto(produto);

            Assert.IsTrue(_listaDeProdutos.RetornarTodosOsItems().Any(i => i.Produto.Nome == "Beterraba"));
        }

    }
}
