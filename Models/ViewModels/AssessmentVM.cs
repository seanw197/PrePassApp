using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrePass.Models
{
    [Microsoft.EntityFrameworkCore.Keyless]
    public class AssessmentVM
    {
        public List<SelectListItem> Dist_list { get; set; }

        public Assessment Assm { get; set; }
        public Applicant Appl { get; set; }

        public Staff staff { get; set; }

        public District district { get; set; }

    }    
}

