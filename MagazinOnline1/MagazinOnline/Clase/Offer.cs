using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline.Clase
{
    public class Offer
    {
        public int ProductId { get; set; }
        public string BuyerEmail { get; set; }
        public string SellerEmail { get; set; }
        public string ProductName { get; set; }
        public decimal OfferPrice { get; set; }
        public DateTime DataOferta { get; set; }
        public bool EsteAprobata { get; set; }
        public bool EsteCumparata { get; set; } = false;
        public DateTime? DataCumparare { get; set; }
    }
}
