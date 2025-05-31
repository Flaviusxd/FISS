using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline.Clase
{
    public class History
    {
        public int ProductId { get; set; }
        public string BuyerEmail { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime BuyingDate { get; set; }
    }
}
