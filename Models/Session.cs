using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrePass.Models
{
    public class Session
    {
        [Key]
        public string Eid { get; set; }

        public string EmpID { get; set; }

        public DateTime dateTime { get; set; }
    }
}
