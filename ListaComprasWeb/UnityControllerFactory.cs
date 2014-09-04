using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ListaCompras.Domain.Interfaces;
using ListaCompras.Domain.Model;
using ListaCompras.Domain.Service;
using ListaDeCompras.Dal;
using Microsoft.Practices.Unity;

namespace ListaComprasWeb
{
    public class UnityControllerFactory: DefaultControllerFactory
    {
        private readonly IUnityContainer _unityContainer;

        public UnityControllerFactory(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentException();
            }

            _unityContainer = unityContainer;
            _unityContainer.RegisterInstance<IProdutoRepository>(ProdutoRepository.Create());
            _unityContainer.RegisterInstance<IItemDeProdutoRepository>(ItemDeProdutoRepository.Create());
            _unityContainer.RegisterInstance<IListaDeProdutos>(new ListaDeProdutos(ProdutoRepository.Create(), ItemDeProdutoRepository.Create()));
            _unityContainer.RegisterInstance<ProdutoServiceTemplate>(new ProdutoService(ProdutoRepository.Create(), ItemDeProdutoRepository.Create()));

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return _unityContainer.Resolve(controllerType) as IController;
        }
    }
}