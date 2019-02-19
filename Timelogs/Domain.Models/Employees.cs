using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Employees
    {
        [Key]
        public string EmployeeID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format($"{LastName}, {FirstName}");
            }
        }

        public Guid DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Departments Department { get; set; }


    }
}
