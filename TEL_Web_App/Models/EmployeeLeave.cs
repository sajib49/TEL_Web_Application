using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public class EmployeeLeave
    {
        public int LeaveID { get; set; }
        public int PartialType { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Select Incharge Name")]
        public int InChargeID { get; set; }
        [Required(ErrorMessage = "Select Leave type")]
        public int LeaveType { get; set; }
        [Required(ErrorMessage = "Please Enter Leave Start Date")]
        public DateTime LeaveStartDate { get; set; }
        [Required(ErrorMessage = "Plase Enter Leave End Date")]
        public DateTime LeaveEndDate { get; set; }
        public DateTime EntryDate { get; set; }
        [Required(ErrorMessage = "Select Leave Reason")]
        public string Reason { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile N")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please Enter Email Address")]
        public string Emailaddress { get; set; }
        public int Status { get; set; }
        public Double LeaveTotal { get; set; }
    }
}