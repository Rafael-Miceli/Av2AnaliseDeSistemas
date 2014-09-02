using System;
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

        public void Criar(IProdutoRepository produtoRepository, IItemDeProdutoRepository itemDeProdutoRepository)
        {
            produtoRepository.AdicionarProduto(this);
            var itemDeProduto = new ItemDeProduto(this, 0, null);
            itemDeProdutoRepository.Adicionar(itemDeProduto);
        }
    }
}
