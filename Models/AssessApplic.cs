
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrePass.Models
{
    //join table
    public class AssessApplic
    {
        [Key]
        public int ID { get; set; }
        [Required]
        //[ForeignKey(string )]
        public string AssessID { get; set; }
        [Required]
        public int AppID { get; set; }
        

    }
}
