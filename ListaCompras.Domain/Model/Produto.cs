using System;
using System.Linq;
using ListaCompras.Domain.Interfaces;

namespace ListaCompras.Domain.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Unidade { get; set; }

        public Produto(string nome, int quantidadeMinima, string unidade)
        {
            Nome = nome;
            QuantidadeMinima = quantidadeMinima;
            Unidade = unidade;
        }

        public static Produto CarregarProduto(int idProduto, IProdutoRepository produtoRepository)
        {
            return produtoRepository.RetornaProdutoPorId(idProduto);
        }

    }

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
            DeletarProduto(produto);
            DeletarProdutoNaLista(produto);
        }


        protected abstract void DeletarProdutoNaLista(Produto produto);

        protected abstract void DeletarProduto(Produto produto);

        protected abstract void AdicionarProdutoNaLista(Produto produto);

        protected abstract void AdicionarProduto(Produto produto);
    }
}
