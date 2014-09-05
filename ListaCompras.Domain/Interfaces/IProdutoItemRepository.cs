using System.Collections.Generic;
using ListaCompras.Domain.Model;

namespace ListaCompras.Domain.Interfaces
{
    public interface IItemDeProdutoRepository
    {
        int Adicionar(ItemDeProduto itemDeProduto);
        void Remover(ItemDeProduto itemDeProduto);
        List<ItemDeProduto> Listar();
        ItemDeProduto BuscarPorId(int id);
    }
}