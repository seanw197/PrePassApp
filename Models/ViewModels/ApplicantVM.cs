using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrePass.Models.ViewModels
{
    public class ApplicantVM
    {
        [Key]
        public int aid { get; set; }
        public Applicant applicant { get; set; }
        public Staff staff { get; set; }
    }
}
