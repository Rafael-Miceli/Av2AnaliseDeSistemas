using System.Linq;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;

namespace ListaCompras.Domain.Service
{
    public class ProdutoService: ProdutoServiceTemplate
    {
        public ProdutoService(IProdutoRepository produtoRepository, IItemDeProdutoRepository itemDeProdutoRepository) :
            base(produtoRepository, itemDeProdutoRepository)
        {}

        protected override void DeletarProdutoNaLista(Produto produto)
        {
            var itemsToRemove = ItemDeProdutoRepository.Listar().Where(i => i.Produto.Id == produto.Id).ToList();

            foreach (var itemDeProduto in itemsToRemove)
            {
                ItemDeProdutoRepository.Remover(itemDeProduto);
            }
        }

        protected override void DeletarProduto(Produto produto)
        {
            ProdutoRepository.Remover(produto);
        }

        protected override void AdicionarProdutoNaLista(Produto produto)
        {
            var itemDeProduto = new ItemDeProduto(produto, 0, null);
            ItemDeProdutoRepository.Adicionar(itemDeProduto);
        }

        protected override void AdicionarProduto(Produto produto)
        {
            ProdutoRepository.AdicionarProduto(produto);
        }
    }
}