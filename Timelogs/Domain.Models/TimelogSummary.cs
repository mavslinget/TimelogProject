using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class TimelogSummary
    {
        public Guid TimelogSummaryID { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public DateTime Time { get; set; }
        public string Department { get; set; }
        public string State { get; set; }
    }
}
