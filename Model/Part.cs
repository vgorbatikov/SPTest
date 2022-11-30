using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTest.Model
{
    class Part
    {
        public int IdPart { get; set; }
        public int IdProduct { get; set; }
        public int IdStock { get; set; }

        public int quantity { get; set; }

        public Part(int IdPart, int IdProduct, int IdStock, int quantity)
        {
            this.IdPart = IdPart;
            this.IdProduct = IdProduct;
            this.IdStock = IdStock;
            this.quantity = quantity;
        }

        public Part(int IdProduct, int IdStock, int quantity)
        {
            this.IdProduct = IdProduct;
            this.IdStock = IdStock;
            this.quantity = quantity;
        }
    }
}
