using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarkodSistem.Models
{
    public class QrCodeInfo
    {
        [Key]
        public int QrCodeInfoID { get; set; }

        public DateTime SKT { get; set; }

        public DateTime TETT { get; set; }

        public DateTime ProductionDate { get; set; }


     
       
 
        public   Product Product { get; set; }




    }
}