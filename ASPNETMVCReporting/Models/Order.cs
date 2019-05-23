using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETMVCReporting.Models
{

    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Oder Number")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string OderNumber { get; set; }

        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "{0} is Required")]
        public int ProductId { get; set; }

        [Display(Name = "Customer Id")]
        [Required(ErrorMessage = "{0} is Required")]
        public int CustomerId { get; set; }

        [Display(Name = "Total Amount")]
        [Required(ErrorMessage = "{0} is Required")]
        public decimal TotalAmount { get; set; }
    }
}