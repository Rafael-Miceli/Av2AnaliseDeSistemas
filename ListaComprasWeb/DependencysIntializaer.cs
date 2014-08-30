using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ListaCompras.Domain.Interfaces;

namespace ListaComprasWeb
{
    public class DependencysIntializaer
    {
        private static DependencysIntializaer _dependencysIntializaerInstance;

        public static DependencysIntializaer Create()
        {
            if (_dependencysIntializaerInstance == null)
            {
                return _dependencysIntializaerInstance = new DependencysIntializaer();
            }

            return _dependencysIntializaerInstance;
        }

        public IProdutoRepository ProdutoRepositoryInstance { get; private set; }

        private DependencysIntializaer()
        {
            InitializeDependencys();
            InitializeData();
        }

        private static void InitializeData()
        {
            
        }

        private static void InitializeDependencys()
        {
        }
    }
}