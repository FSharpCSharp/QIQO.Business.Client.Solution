﻿using QIQO.Business.Client.Contracts;
using QIQO.Business.Client.Entities;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Linq;

namespace QIQO.Business.Client.Core.UI
{
    public class ProductListService : IProductListService
    {
        IServiceFactory _service_factor;
        public ProductListService(IServiceFactory service_factory)
        {
            _service_factor = service_factory;
            Initialize();
        }

        private void Initialize()
        {
            IProductService product_service = _service_factor.CreateClient<IProductService>();
            ICurrentCompanyService curr_co = Unity.Container.Resolve<ICurrentCompanyService>();
            using (product_service)
            {
                try
                {
                    var prod_list = product_service.GetProducts(curr_co.CurrentCompany);
                    ProductList = new List<Product>(prod_list.OrderBy(p => p.ProductType).ThenBy(p => p.ProductName).ToList());
                }
                catch
                {
                    ProductList = new List<Product>();
                }
            }
        }

        public List<Product> ProductList { get; private set; }
    }
}
