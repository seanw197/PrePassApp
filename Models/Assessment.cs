using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PrePass.Models
{
    public enum PresReason
    {
        [Display(Name = "Addiction")] Addiction = 0,
        [Display(Name = "Notice to Quit")] Notice_to_Quit = 1,
        [Display(Name = "Cannot afford Rent")] Cannot_afford_Rent = 2,
        [Display(Name = "Domestic Violence")] Domestic_Violence = 3,
        [Display(Name = "Court Order")] Court_Order = 4,
        [Display(Name = "Barring Order")] Barring_Order = 5,
        [Display(Name = "Family Circumstance")] Family_Circumstance = 6,
        [Display(Name = "Relationship Breakdown")] Relationship_Breakdown = 7,
        [Display(Name = "Intellectual or Physical Disability")] Intellectual_or_Physical_Disability = 8,
        [Display(Name = "Mental Illness")] Mental_Illness = 9,
        [Display(Name = "Leaving Care, Hospital or Prison")] Leaving_Care_or_Hospital_or_Prison = 10,
        [Display(Name = "Rough Sleeping")] Rough_Sleeping = 11,
        [Display(Name = "Sofa Surfing")] Sofa_Surfing = 12
    };

    public enum HouseholdType
    {
        [Display(Name = "Single")] Single = 0,
        [Display(Name = "Couple")] Couple = 1,
        [Display(Name = "Separated or Divorced")] Separated_Divorced = 2,
        [Display(Name = "Widower")] Widower = 3,
        [Display(Name = "Other")] Other = 4
    }

    public enum AddictionType
    {
        [Display(Name = "No Addiction Issues Now Or In Past ")] No_addiction_issues_now_or_in_past = 0, 
        [Display(Name = "Addiction Issues In The Past. Treated And Recovered ")] Addiction_issues_in_the_past_treated_and_recovered = 1,
        [Display(Name = "Currently Seeking Treatment For Active Addiction ")] Currently_seeking_treatment_for_active_addiction = 2,
        [Display(Name = "Currently Receiving Treatment For Active Addiction ")] Currently_receiving_treatment_for_active_addiction = 3
    }

    public enum IncomeType
    {
        [Display(Name = "Social Welfare")] Social_Welfare = 0,
        [Display(Name = "Employed")] Employed = 1,
        [Display(Name = "No Income")] No_Income = 2
    }

    public enum StatusType
    {
        [Display(Name = "Placed in Emergency Accomodation")] Placed_in_Emergency_Accomodation = 0,
        [Display(Name = "Referred to Another Agency")]  Referred_to_Another_Agency= 1,
        [Display(Name = "Referred to Another Local Authority")] Referred_to_Another_Local_Authority = 2,
        [Display(Name = "Referred to Family and Friends")] Referred_to_Family_and_Friends = 3,
        [Display(Name = "Deemed Not Homeless")] Deemed_Not_Homeless = 4,
        [Display(Name = "Ongoing")] Ongoing = 5
    }
    public class Assessment
    {
        [Key]
        [Display(Name = "Case Number")]
        public int AssessID { get; set; }

        [Required]
        public int AppID { get; set; }

        [Display(Name = "Last Updated By")]
        public string EmpID { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d/M/yyyy HH:mm:ss}")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Last Updated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d/M/yyyy HH:mm:ss}")]
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Housing Reference")]
        [MinLength(3)]
        [MaxLength(24)]
        public string HousingRef { get; set; }

        [Display(Name = "Reason for Presenting as Homeless")]
        public PresReason Reason { get; set; }

        [Display(Name = "Income Status")]
        public IncomeType Income { get; set; }

        [Display(Name = "Local Authority")]
        public int DistrictID { get; set; }

        [Display(Name = "Have you ever been convicted of a criminal offence?")]
        public bool CriminalOff { get; set; }

        [Display(Name = "Household Type")]
        public HouseholdType Household { get; set; }

        [Display(Name = "Number Of Children Under 18")]
        [Range(0,30)]     
        public int ChildrenUnder18 { get; set; }


        [Display(Name = "Number Of Children Over 18")]
        [Range(0, 30)]
        public int ChildrenOver18 { get; set; }

        
        [Display(Name = "Addiction Issues for any household members?")]
        public AddictionType Addiction { get; set; }

        [MaxLength(240)]
        [Display(Name = "Any physical or mental health conditions of household members?")]
        public string HealthConditions { get; set; }

        [Display(Name = "Any current legal issues pending?")]
        public bool LegalIssues { get; set; }

        [Display(Name = "On temporary release from prison?")]
        public bool TempRelease { get; set; }

        [Display(Name = "If currently on probation, have you a probation officer?")]
        public bool ProbationOfficer { get; set; }

        [Display(Name = "Tusla/Social Worker")]
        public bool SocialWorker { get; set; }

        [Display(Name = "Department of Social Protection / Community Welfare Officer")]
        public bool DeptSocial { get; set; }

        [Display(Name = "Addiction Services ")]
        public bool AddictionSvcs { get; set; }

        [Display(Name = "Mental Health Community Team")]
        public bool MHCT { get; set; }

        [Display(Name = "Doctor/GP")]
        public bool DoctorGP { get; set; }

        [Display(Name = "Keyworker in any support service such as domestic violence")]
        public bool Keyworker { get; set; }


        [Display(Name = "Other Supports currently linked into")]
        [MaxLength(240)]
        public string OtherSupports { get; set; }

        [Display(Name = "Supports Referred by Assessment Officer")]
        [MaxLength(240)]
        public string SupprtsReferred { get; set; }

        [Display(Name = "Relevant Further Information")]
        public string FurtherInfo { get; set; }

        [Display(Name = "Case Status")]
        public StatusType Status { get; set; }

    }

}
