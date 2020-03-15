using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using StoreBook.Domain.Concrete;
namespace StoreBook.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kerenelParam) {
            kernel = kerenelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            return kernel.GetAll(serviceType);
        }
        public void AddBindings() 
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
        }

    }
}