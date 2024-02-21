﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBMS.Models
{
    public partial class PurchaseOfrawmaterials
    {
        public short Id { get; set; }
        public short? RawMaterials { get; set; }
        public float? CountPur { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual Rawmaterials RawMaterialsNavigation { get; set; }
    }
}
