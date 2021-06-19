using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UnitCost { get; set; }
        public int Quantity { get; set; }

        public int Size { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int ID_Category { get; set; }

    }
}