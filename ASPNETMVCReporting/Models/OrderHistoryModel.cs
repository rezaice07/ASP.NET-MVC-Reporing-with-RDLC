using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMVCReporting.Models
{
    public class OrderHistoryModel
    {
        public string OderNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalAmount { get; set; }       
    }
}