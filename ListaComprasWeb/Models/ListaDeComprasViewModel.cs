using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaComprasWeb.Models
{
    public class ProdutoItemViewModel
    {
        public DateTime Validade { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

    }
}