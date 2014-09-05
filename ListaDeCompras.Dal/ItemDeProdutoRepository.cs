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

        public int Adicionar(ItemDeProduto itemDeProduto)
        {
            var itemDeProdutoId = IncrementarId(itemDeProduto);
            _itemDeProdutosEmMemoria.Add(itemDeProduto);
            return itemDeProdutoId;
        }

        public void Remover(ItemDeProduto itemDeProduto)
        {
            _itemDeProdutosEmMemoria.Remove(itemDeProduto);
        }

        private int IncrementarId(ItemDeProduto itemDeProduto)
        {
            if (_itemDeProdutosEmMemoria.Count == 0)
            {
                itemDeProduto.Id = 1;
                return 1;
            }
            else
            {
                var maiorId = _itemDeProdutosEmMemoria.Max(p => p.Id);
                itemDeProduto.Id = maiorId + 1;
                return maiorId + 1;
            }
            
        }

        public ItemDeProduto BuscarPorId(int id)
        {
            return _itemDeProdutosEmMemoria.Find(p => p.Id == id);
        }

        public List<ItemDeProduto> Listar()
        {
            return _itemDeProdutosEmMemoria;
        }

        public void CriarDummies(List<Produto> produtos)
        {

            var papelHigienico = produtos.Find(p => p.Id == 1);
            var arroz = produtos.Find(p => p.Id == 2);
            var feijao = produtos.Find(p => p.Id == 3);
            var batata = produtos.Find(p => p.Id == 4);
            var alface = produtos.Find(p => p.Id == 5);

            var papelHigienicoItem1 = new ItemDeProduto(papelHigienico, 1, new DateTime(2014, 09, 15));
            var papelHigienicoItem2 = new ItemDeProduto(papelHigienico, 1, new DateTime(2014, 09, 28));

            var arrozItem1 = new ItemDeProduto(arroz, 0, new DateTime(2014, 09, 28));

            var feijaoItem1 = new ItemDeProduto(feijao, 0, null);

            var batataItem1 = new ItemDeProduto(batata, 1, new DateTime(2014, 09, 15));
            var batataItem2 = new ItemDeProduto(batata, 2, new DateTime(2014, 09, 17));

            var alfaceItem1 = new ItemDeProduto(alface, 0, new DateTime(2014, 09, 17));

            Adicionar(papelHigienicoItem1);
            Adicionar(papelHigienicoItem2);
            Adicionar(arrozItem1);
            Adicionar(feijaoItem1);
            Adicionar(batataItem1);
            Adicionar(batataItem2);
            Adicionar(alfaceItem1);
        }
    }
}
