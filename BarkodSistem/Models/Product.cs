using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarkodSistem.Models
{
    public class Product
    {
        [Key,ForeignKey("QrCodeInfo")]
        public int ProductID { get; set; }

        public string ProductName { get; set; }


        public string Size { get; set; }

        public int UnitsInStock { get; set; }

       
        //public int QrCodeInfoID { get; set; }

        public  QrCodeInfo QrCodeInfo { get; set; }

        public int CategoryID { get; set; }
        public  Category Category { get; set; }

    }
}