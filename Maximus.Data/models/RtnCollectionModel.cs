using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
 public class RtnCollectionModel
    {
        [Required]
        [Display(Name ="Contact number")]
        public int ContactNo { get; set; }
        [Required]
        [Display(Name = "Contact name")]
        public string ContactName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string EmailId { get; set; }
    }
}
