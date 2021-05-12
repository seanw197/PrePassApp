using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrePass.Models
{
    public class AssessmentDetailsVM
    {
        [Key]
        public int aid { get; set; }
        public string AssessorName { get; set; }
        public string DistrictName { get; set; }

        public Assessment assessment { get; set; }
        public Applicant applicant { get; set; }
    }
}
