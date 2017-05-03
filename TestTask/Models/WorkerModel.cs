using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class WorkerModel
    {
        public int WorkerId { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middlename")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Entry date")]
        public DateTime EntryDate { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        public int CompanyId { get; set; }

        public CompanyModel Company { get; set; }
    }
}