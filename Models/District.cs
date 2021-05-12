using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrePass.Models
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }

        [Required]
        [Display(Name = "Local Authority:")]
        [MinLength(3)]
        [MaxLength(240)]
        public string DistrictName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }


    }
}
