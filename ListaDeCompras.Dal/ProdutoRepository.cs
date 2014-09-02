using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;

namespace ListaDeCompras.Dal
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static ProdutoRepository _produtoRepositoryInstance;
        private readonly List<Produto> _produtosEmMemoria = new List<Produto>();

        private ProdutoRepository()
        {}

        public static ProdutoRepository Create()
        {
            if (_produtoRepositoryInstance == null)
                return _produtoRepositoryInstance = new ProdutoRepository();

            return _produtoRepositoryInstance;
        }

        public void AdicionarProduto(Produto produto)
        {
            IncrementarId(produto);
            _produtosEmMemoria.Add(produto);
        }

        private void IncrementarId(Produto produto)
        {
            if (_produtosEmMemoria.Count == 0)
            {
                produto.Id = 1;
            }
            else
            {
                var maiorId = _produtosEmMemoria.Max(p => p.Id);
                produto.Id = maiorId + 1;    
            }
            
        }

        public void AtualizarProduto(Produto produto)
        {
            var produtoParaAtualizar = _produtosEmMemoria.First(p => p.Id == produto.Id);

            produtoParaAtualizar.Nome = produto.Nome;
            produtoParaAtualizar.QuantidadeMinima = produto.QuantidadeMinima;
        }

        public Produto RetornaProdutoPorId(int id)
        {
            return _produtosEmMemoria.Find(p => p.Id == id);
        }

        public List<Produto> RetornarProdutos()
        {
            return _produtosEmMemoria;
        }

        public void Remover(Produto produto)
        {
            _produtosEmMemoria.Remove(produto);
        }

        public void CriarDummies()
        {
            var papelHigienico = new Produto("Papel Higiênico", 3, "");
            var arroz = new Produto("Arroz", 1, "Kg");
            var feijao = new Produto("Feijão", 1, "Kg");
            var batata = new Produto("Batata Inglesa", 2, "");
            var alface = new Produto("Alface", 0, "");

            AdicionarProduto(papelHigienico);
            AdicionarProduto(arroz);
            AdicionarProduto(feijao);
            AdicionarProduto(batata);
            AdicionarProduto(alface);
        }
    }
}
