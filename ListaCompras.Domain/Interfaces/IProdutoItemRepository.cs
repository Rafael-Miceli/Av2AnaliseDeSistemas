using System.Collections.Generic;
using ListaCompras.Domain.Model;

namespace ListaCompras.Domain.Interfaces
{
    public interface IItemDeProdutoRepository
    {
        void Adicionar(ItemDeProduto itemDeProduto);
        void Remover(ItemDeProduto itemDeProduto);
        List<ItemDeProduto> Listar();
        ItemDeProduto BuscarPorId(int id);
    }
}