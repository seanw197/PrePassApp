using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PrePass.Models
{
    public enum AccessType { Assessor, Manager, SuperUser }

    public class Staff
    {
        [Key]
        [Required]
        [Display(Name = "Employee ID")]
        [MinLength(3)]
        [MaxLength(10)]
        public string EmpID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Must be a valid Email Address")]      
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Passwd { get; set; }


        [Display(Name = "Role")]
        public AccessType accessLevel { get; set; }
        public bool Active { get; set; }
    }

}
