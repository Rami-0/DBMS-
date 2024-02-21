using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBMS.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Production = new HashSet<Production>();
            PurchaseOfrawmaterials = new HashSet<PurchaseOfrawmaterials>();
            Saleofproducts = new HashSet<Saleofproducts>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public short? Position { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public virtual Positions PositionNavigation { get; set; }
        public virtual ICollection<Production> Production { get; set; }
        public virtual ICollection<PurchaseOfrawmaterials> PurchaseOfrawmaterials { get; set; }
        public virtual ICollection<Saleofproducts> Saleofproducts { get; set; }
    }
}
