using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline.Clase
{
    public class SaleRecord
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SellerEmail { get; set; }
        public string BuyerEmail { get; set; }
        public decimal PretOriginal { get; set; }
        public decimal PretVanzare { get; set; }
        public DateTime DataVanzare { get; set; }
        public bool EsteNegociat { get; set; }
    }
}
