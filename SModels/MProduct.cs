using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class MProduct
    {
        public MProduct(string name, double price) {
            this.Name = name;
            this.Price = price;
        }
        public MProduct(string barcode, string name, double price) : this(name, price)
        {
            this.Barcode = barcode;
        }
        public MProduct() {

        }
        public string Name { get; set; }
        public double Price { get; set; }

        [Key]
        public string Barcode {get; set;}

        public List<MLocation> MLocation {get; set;}

        public override string ToString()
        {
            return $"Product Name: {Name}\n Price: {Price}.00";
        }
        public bool Equals(MProduct product)
        {
            return this.Name.Equals(product.Name) && this.Price.Equals(product.Price);
        }
    }
}