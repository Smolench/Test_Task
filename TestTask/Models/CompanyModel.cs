using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Size")]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Form")]
        public string Form { get; set; }
    }
}