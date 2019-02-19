using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Departments
    {
        [Key]
        public Guid DepartmentID { get; set; }
        
        public string DepartmentName { get; set; }
    }
}
