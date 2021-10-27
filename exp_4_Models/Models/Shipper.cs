using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        [MaxLength(15, ErrorMessage = "En fazla 15 Karakter girebilirsiniz")]
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}