using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline.Clase
{
    public class Seller : User
    {
        public bool IsApproved { get; set; } = false;
        public bool IsActive { get; set; } = true;

    }
}
