using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETMVCReporting.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} is Required")]
        public int Id { get; set; }

        [Display(Name = "Fist Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string FistName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string Email { get; set; }

        [Display(Name = "Cellphone")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string Cellphone { get; set; }

        [Display(Name = "Address")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string Address { get; set; }
    }
}