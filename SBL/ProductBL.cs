using System.Collections.Generic;
using Models;
using SDL;
using System;
namespace SBL
{
    public class ProductBL: IProductBL
    {
        private IRepository _repo;
        public ProductBL(IRepository repo){
            _repo = repo;
        }

        public MProduct AddAProduct(MProduct product)
        {
            return _repo.AddProduct(product);
        }

        public List<MProduct> GetAllProducts()
        {
            return _repo.GetAllProductss();
        }
        public MProduct GetAProduct(MProduct product){
            Console.WriteLine(product.ToString());
            if(_repo.GetAProduct(product) != null){
                throw new Exception("Product already Exit!");
            }
            return _repo.GetAProduct(product);
        }

        public MProduct searchAProduct(string barcode)
        {
            return _repo.searchAProduct(barcode);
        }
    }
}