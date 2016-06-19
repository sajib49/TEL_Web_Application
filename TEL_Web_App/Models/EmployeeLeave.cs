using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public class EmployeeLeave
    {
        public int LeaveID { get; set; }
        public int EmployeeID { get; set; }
        public int InChargeID { get; set; }
        public int LeaveType { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string Reason { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Emailaddress { get; set; }
        public int Status { get; set; }
        public Double LeaveTotal { get; set; }
    }
}