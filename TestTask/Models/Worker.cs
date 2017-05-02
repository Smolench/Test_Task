using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Worker
    {
        [Display(Name = "Id")]
        public int WorkerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second name is required.")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Middle name is required.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Entry date is required.")]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string Company { get; set; }
    }
}