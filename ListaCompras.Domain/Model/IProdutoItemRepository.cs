using System.Collections.Generic;

namespace ListaCompras.Domain.Model
{
    public interface IItemDeProdutoRepository
    {
        void Adicionar(ItemDeProduto itemDeProduto);
        void Remover(ItemDeProduto itemDeProduto);
        List<ItemDeProduto> Listar();
        ItemDeProduto BuscarPorId(int id);
    }
}