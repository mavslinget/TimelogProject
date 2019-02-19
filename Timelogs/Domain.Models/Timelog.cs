using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Timelog
    {
        [Key]
        public Guid LogID { get; set; }

        public string EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public Employees Employee { get; set; }
        
        public DateTime Time { get; set; }

        public string State { get; set; }
    }
}
