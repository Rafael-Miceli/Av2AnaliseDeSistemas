using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaComprasWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }   
}
