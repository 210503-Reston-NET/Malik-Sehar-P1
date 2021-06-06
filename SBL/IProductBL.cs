using System.Collections.Generic;
using Models;
namespace SBL
{
    public interface IProductBL
    {
        List<MProduct> GetAllProducts();
        MProduct AddAProduct(MProduct product);
        MProduct GetAProduct(MProduct product);
        MProduct searchAProduct(string barcode);
        MProduct GetProductById(string Barcode);
        public MProduct DeleteAProduct(MProduct mProduct);
        MProduct UpdateProduct(MProduct product);
    }
}