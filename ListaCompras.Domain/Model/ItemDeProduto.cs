using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompras.Domain.Model
{
    public class ItemDeProduto
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }

        public ItemDeProduto(Produto produto, int quantidade, DateTime validade)
        {
            Produto = produto;
            Quantidade = quantidade;
            Validade = validade;
        }
    }
}
