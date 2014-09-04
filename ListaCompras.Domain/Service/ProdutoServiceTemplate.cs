using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;

namespace ListaCompras.Domain.Service
{
    public abstract class ProdutoServiceTemplate
    {
        protected readonly IProdutoRepository ProdutoRepository;
        protected readonly IItemDeProdutoRepository ItemDeProdutoRepository;

        protected ProdutoServiceTemplate(IProdutoRepository produtoRepository, IItemDeProdutoRepository itemDeProdutoRepository)
        {
            ProdutoRepository = produtoRepository;
            ItemDeProdutoRepository = itemDeProdutoRepository;
        }

        public virtual void Criar(Produto produto)
        {
            AdicionarProduto(produto);
            AdicionarProdutoNaLista(produto);
        }

        public virtual void Deletar(Produto produto)
        {
            DeletarProdutoNaLista(produto);
            DeletarProduto(produto);
        }

        public void Editar(Produto produto)
        {
            ProdutoRepository.AtualizarProduto(produto);
        }


        protected abstract void DeletarProdutoNaLista(Produto produto);

        protected abstract void DeletarProduto(Produto produto);

        protected abstract void AdicionarProdutoNaLista(Produto produto);

        protected abstract void AdicionarProduto(Produto produto);
    }
}