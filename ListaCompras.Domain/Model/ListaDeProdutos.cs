using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaCompras.Domain.Interfaces;

namespace ListaCompras.Domain.Model
{
    public class ListaDeProdutos : IListaDeProdutos
    {
        private readonly IProdutoRepository _produtoRepository;
        public  List<ItemDeProduto> ListaComProdutos { get; private set; }

        public ListaDeProdutos(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            ListaComProdutos = new List<ItemDeProduto>();
        }

        public void AdicionarNovoItem(ItemDeProduto itemDeProduto)
        {
            ValidadeEmItemDoProdutoNaoForValidaCriaDataAutomatica(itemDeProduto, 7);
            ListaComProdutos.Add(itemDeProduto);
        }

        public void AtualizarItem(ItemDeProduto itemDeProduto)
        {
            var itemDeProdutoParaAtualizar = ListaComProdutos.Find(i => i.Id == itemDeProduto.Id);

            itemDeProdutoParaAtualizar.Quantidade = itemDeProduto.Quantidade;

            if (ValidadeEmItemDoProdutoForValida(itemDeProduto))
                itemDeProdutoParaAtualizar.Validade = itemDeProduto.Validade;
            else
                Console.WriteLine("Validade ja existente do produto " + itemDeProduto.Produto.Nome + " na lista");

        }

        public void RemoverItem(int itemDeProdutoId)
        {
            var itemDeProduto = ListaComProdutos.Find(i => i.Id == itemDeProdutoId);

            if (PodeRemoverItem(itemDeProduto))
                ListaComProdutos.Remove(itemDeProduto);
        }

        public List<ItemDeProduto> MontarListaDeCompras()
        {
            var listaDeCompras = new List<ItemDeProduto>();

            foreach (var produto in _produtoRepository.RetornarProdutos())
            {
                var totalDeProdutosNaLista = ListaComProdutos.Count(i => i.Produto.Id == produto.Id);

                if (totalDeProdutosNaLista <= produto.QuantidadeMinima)
                    listaDeCompras.AddRange(ListaComProdutos.Where(i => i.Produto.Id == produto.Id));
                    
            }

            return listaDeCompras;
        }




        private bool PodeRemoverItem(ItemDeProduto itemDeProduto)
        {
            return ListaComProdutos.Any(i => i.Produto.Id == itemDeProduto.Produto.Id);
        }

        private bool ValidadeEmItemDoProdutoForValida(ItemDeProduto itemDeProduto)
        {
            var itemsDeProdutosDoProdutoTal = ListaComProdutos.Where(p => p.Produto.Id == itemDeProduto.Id);

            if(!itemsDeProdutosDoProdutoTal.Any(i => i.Validade == itemDeProduto.Validade && i.Id != itemDeProduto.Id))
                return true;

            return false;
        }

        private void ValidadeEmItemDoProdutoNaoForValidaCriaDataAutomatica(ItemDeProduto itemDeProduto, double numeroDeDias)
        {
            var itemsDeProdutosDoProdutoTal = ListaComProdutos.Where(p => p.Produto.Id == itemDeProduto.Id);

            if (itemsDeProdutosDoProdutoTal.Any(i => i.Validade == itemDeProduto.Validade && i.Id != itemDeProduto.Id))
            {
                itemDeProduto.Validade = DateTime.Now.AddDays(numeroDeDias);
                ValidadeEmItemDoProdutoNaoForValidaCriaDataAutomatica(itemDeProduto, numeroDeDias + 1);
            }
        }
    }
}
