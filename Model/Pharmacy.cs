using System;

namespace SPTest.Model
{
    class Pharmacy
    {
        public int IdPharmacy { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }

        public Pharmacy(int IdPharmacy, String Name, String Address, String Phone)
        {
            this.IdPharmacy = IdPharmacy;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
        }

        public Pharmacy(String Name, String Address, String Phone)
        {
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
        }
    }
}
