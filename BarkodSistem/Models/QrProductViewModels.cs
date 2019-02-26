using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarkodSistem.Models
{
    public class QrProductViewModels
    {

        public int QrCodeInfoID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public string ProductName { get; set; }
        public string Size { get; set; }

        public int UnitsInStock { get; set; }
        public DateTime SKT { get; set; }

        public DateTime TETT { get; set; }

        public DateTime ProductionDate { get; set; } = DateTime.Now;

    }
}