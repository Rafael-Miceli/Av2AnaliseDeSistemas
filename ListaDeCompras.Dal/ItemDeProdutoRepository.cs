using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;

namespace ListaDeCompras.Dal
{
    public class ItemDeProdutoRepository : IItemDeProdutoRepository
    {
        private static ItemDeProdutoRepository _itemDeProdutoRepositoryInstance;
        private readonly List<ItemDeProduto> _itemDeProdutosEmMemoria = new List<ItemDeProduto>();

        private ItemDeProdutoRepository()
        {}

        public static ItemDeProdutoRepository Create()
        {
            if (_itemDeProdutoRepositoryInstance == null)
                return _itemDeProdutoRepositoryInstance = new ItemDeProdutoRepository();

            return _itemDeProdutoRepositoryInstance;
        }

        public void Adicionar(ItemDeProduto itemDeProduto)
        {
            IncrementarId(itemDeProduto);
            _itemDeProdutosEmMemoria.Add(itemDeProduto);
        }

        public void Remover(ItemDeProduto itemDeProduto)
        {
            _itemDeProdutosEmMemoria.Remove(itemDeProduto);
        }

        private void IncrementarId(ItemDeProduto produto)
        {
            var maiorId = _itemDeProdutosEmMemoria.Max(p => p.Id);
            produto.Id = maiorId + 1;
        }

        public ItemDeProduto BuscarPorId(int id)
        {
            return _itemDeProdutosEmMemoria.Find(p => p.Id == id);
        }

        public List<ItemDeProduto> Listar()
        {
            return _itemDeProdutosEmMemoria;
        }
    }
}
