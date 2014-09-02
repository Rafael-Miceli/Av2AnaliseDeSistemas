using System.Collections.Generic;
using ListaCompras.Domain.Model;

namespace ListaCompras.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void AdicionarProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        Produto RetornaProdutoPorId(int id);
        List<Produto> RetornarProdutos();
        void Remover(Produto produto);
    }
}