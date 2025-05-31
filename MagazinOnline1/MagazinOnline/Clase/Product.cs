using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline.Clase
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string VanzatorEmail { get; set; }
        public string Description { get; set; }
        public bool EsteNegociabil { get; set; }
        public decimal? PretMinim { get; set; }
        public decimal? MinPrice { get; set; }

    }
}
