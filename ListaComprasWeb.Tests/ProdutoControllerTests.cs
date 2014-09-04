using System;
using ListaCompras.Domain.Service;
using ListaComprasWeb.Controllers;
using ListaDeCompras.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListaCompras.Domain.Model;

namespace ListaComprasWeb.Tests
{
    [TestClass]
    public class ProdutoControllerTests
    {
        [TestMethod]
        public void Given_A_Request_To_Create_A_Product_When_Create_Product_Then_Create_Product_With_No_Errors()
        {
            var produto = new Produto("Beterraba", 1, "");

            var produtoController = new ProdutoController(ProdutoRepository.Create(), new ProdutoService(ProdutoRepository.Create(), ItemDeProdutoRepository.Create()));

            var resultado = produtoController.Create(produto);

            Assert.IsNotNull(resultado);
        }
    }
}
