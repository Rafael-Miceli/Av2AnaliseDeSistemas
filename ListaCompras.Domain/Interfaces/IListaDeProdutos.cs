using System.Collections.Generic;
using ListaCompras.Domain.Model;

namespace ListaCompras.Domain.Interfaces
{
    public interface IListaDeProdutos
    {
        void AdicionarNovoItem(ItemDeProduto itemDeProduto);
        void AtualizarItem(ItemDeProduto itemDeProduto);
        void RemoverItem(int itemDeProdutoId);
        List<ItemDeProduto> MontarListaDeCompras();
        List<ItemDeProduto> RetornarTodosOsItems();
    }
}