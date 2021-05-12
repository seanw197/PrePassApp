using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PrePass.Models
{
    public enum GenderType 
    {
        [Display(Name = "Male")] Male = 0,
        [Display(Name = "Female")] Female = 1,
        [Display(Name = "Other")] Other = 2 
    }
    public enum EthnicType
    {
        [Display(Name = "Asian or Chinese")] Asian_Chinese = 0,
        [Display(Name = "Black EU")] Black_EU = 1,
        [Display(Name = "Black Non EU")] Black_Non_EU = 2,
        [Display(Name = "Black Irish")] Black_Irish = 3,
        [Display(Name = "Traveller Irish")] Traveller_Irish = 4,
        [Display(Name = "Traveller Non Irish")] Traveller_Non_Irish = 5,
        [Display(Name = "White EU")] White_EU = 6,
        [Display(Name = "White Irish")] White_Irish = 7,
        [Display(Name = "White Non EU")] White_Non_EU = 8,
        [Display(Name = "Other")] Other = 9
    }
    public class Applicant
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int AppID { get; set; }

        //public int AppID { get; set; }
        [Display(Name = "PPS Number")]
        [MaxLength(24)]
        public string PPSN { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(40)]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(40)]
        public string LName { get; set; }


        [Display(Name = "Date of Birth D/M/YYYY")]
        [DataType(DataType.Date)]        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d/M/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Contact Phone")]
        [MaxLength(40)]
        [Phone]
        public string ContactNumber { get; set; }


        [Display(Name = "Last Address")]
        [MaxLength(240)]
        public string LastKnownAddress { get; set; }

        public GenderType Gender { get; set; }

        public EthnicType Ethnicity { get; set; }

        [Display(Name = "Record Last Updated")]
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Last updated by")]
        public string EmpID { get; set; }

        public bool Active { get; set; }

    }
}
