using System;

namespace SPTest.Model
{
    class Product
    {
        public int IdProduct { get; set; }
        public String Name { get; set; }

        public Product(int IdProduct, String Name)
        {
            this.IdProduct = IdProduct;
            this.Name = Name;
        }

        public Product(String Name)
        {
            this.Name = Name;
        }
    }
}
