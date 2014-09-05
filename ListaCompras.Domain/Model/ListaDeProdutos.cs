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
        private readonly IItemDeProdutoRepository _produtoItemRepository;

        public ListaDeProdutos(IProdutoRepository produtoRepository, IItemDeProdutoRepository produtoItemRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoItemRepository = produtoItemRepository;
        }

        public int AdcionarItem(int produtoId)
        {
            var produto = _produtoRepository.RetornaProdutoPorId(produtoId);
            var itemDeProduto = new ItemDeProduto(produto, 1, null);
            return _produtoItemRepository.Adicionar(itemDeProduto);
            
        }

        public void AdicionarItemComNovaValidade(ItemDeProduto itemDeProduto)
        {
            ValidadeEmItemDoProdutoNaoForValidaCriaDataAutomatica(itemDeProduto, 7);
            _produtoItemRepository.Adicionar(itemDeProduto);
        }

        public void AtualizarItem(ItemDeProduto itemDeProduto)
        {
            var itemDeProdutoParaAtualizar = _produtoItemRepository.BuscarPorId(itemDeProduto.Id);

            itemDeProdutoParaAtualizar.Quantidade = itemDeProduto.Quantidade;

            if (ValidadeEmItemDoProdutoForValida(itemDeProduto))
                itemDeProdutoParaAtualizar.Validade = itemDeProduto.Validade;
            else
                Console.WriteLine("Validade ja existente do produto " + itemDeProduto.Produto.Nome + " na lista");

        }

        public void RemoverItem(int itemDeProdutoId)
        {
            var itemDeProduto = _produtoItemRepository.BuscarPorId(itemDeProdutoId);

            if (PodeRemoverItem(itemDeProduto))
                _produtoItemRepository.Remover(itemDeProduto);
        }

        public List<ItemDeProduto> MontarListaDeCompras()
        {
            var listaDeCompras = new List<ItemDeProduto>();

            foreach (var produto in _produtoRepository.RetornarProdutos())
            {
                var totalDeProdutosNaLista = _produtoItemRepository.Listar().Where(i => i.Produto.Id == produto.Id).Sum(q => q.Quantidade);

                if (totalDeProdutosNaLista < produto.QuantidadeMinima)
                    listaDeCompras.AddRange(_produtoItemRepository.Listar().Where(i => i.Produto.Id == produto.Id));
                    
            }

            return listaDeCompras;
        }

        public List<ItemDeProduto> RetornarTodosOsItems()
        {
            return _produtoItemRepository.Listar();
        }



        private bool PodeRemoverItem(ItemDeProduto itemDeProduto)
        {
            return _produtoItemRepository.Listar().Any(i => i.Produto.Id == itemDeProduto.Produto.Id);
        }

        private bool ValidadeEmItemDoProdutoForValida(ItemDeProduto itemDeProduto)
        {
            var itemsDeProdutosDoProdutoTal = _produtoItemRepository.Listar().Where(p => p.Produto.Id == itemDeProduto.Id);

            if(!itemsDeProdutosDoProdutoTal.Any(i => i.Validade == itemDeProduto.Validade && i.Id != itemDeProduto.Id))
                return true;

            return false;
        }

        private void ValidadeEmItemDoProdutoNaoForValidaCriaDataAutomatica(ItemDeProduto itemDeProduto, double numeroDeDias)
        {
            var itemsDeProdutosDoProdutoTal = _produtoItemRepository.Listar().Where(p => p.Produto.Id == itemDeProduto.Id);

            if (itemsDeProdutosDoProdutoTal.Any(i => i.Validade == itemDeProduto.Validade && i.Id != itemDeProduto.Id))
            {
                itemDeProduto.Validade = DateTime.Now.AddDays(numeroDeDias);
                ValidadeEmItemDoProdutoNaoForValidaCriaDataAutomatica(itemDeProduto, numeroDeDias + 1);
            }
        }
    }
}
