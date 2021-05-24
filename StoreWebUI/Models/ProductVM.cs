using Models;

namespace StoreWebUI.Models
{
    public class ProductVM
    {
        public ProductVM(MProduct product)
        {
            Barcode = product.Barcode;
            Name = product.Name;
            Price = product.Price;
        }
        public ProductVM()
        {

        }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
