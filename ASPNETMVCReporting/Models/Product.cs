using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETMVCReporting.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string ProductName { get; set; }

        [Display(Name = "Regular Price")]
        [Required(ErrorMessage = "{0} is Required")]
        public decimal RegularPrice { get; set; }

        [Display(Name = "Discount Price")]
        [Required(ErrorMessage = "{0} is Required")]
        public decimal DiscountPrice { get; set; }

        [Display(Name = "Description")]
        [StringLength(250, ErrorMessage = "Maximum length is {1}")]
        public string Description { get; set; }

    }
}