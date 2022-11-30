using System;

namespace SPTest.Model
{
    class Stock
    {
        public int IdStock { get; set; }
        public int IdPharmacy { get; set; }

        public String Name { get; set; }

        public Stock(int IdStock, int IdPharmacy, String Name)
        {
            this.IdStock = IdStock;
            this.IdPharmacy = IdPharmacy;
            this.Name = Name;
        }

        public Stock(int IdPharmacy, String Name)
        {
            this.IdPharmacy = IdPharmacy;
            this.Name = Name;
        }
    }
}
