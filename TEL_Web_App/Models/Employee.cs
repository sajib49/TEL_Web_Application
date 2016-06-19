using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string CardNo { get; set; }
        public string Photograph { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ConfirmDate { get; set; }

        public string PresentAddress { get; set; }
        public string PermanantAddress { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public int MobileID { get; set; }

        public string Email { get; set; }
        public string Fax { get; set; }

        public string Nationality { get; set; }
        public string PlaceofBirth { get; set; }
        public string Religion { get; set; }

        public string MaritialStatus { get; set; }
        public string BloodGroup { get; set; }

        public string PassportNo { get; set; }

        public string TINNo { get; set; }
        public string NationalID { get; set; }
        public string FatherName { get; set; }

        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }

        public string MotherOccupation { get; set; }

        public DateTime MarriageDate { get; set; }
        public string SpouseName { get; set; }

        public string SpouseOccupation { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public string Department { get; set; }

        public int GradeID { get; set; }
        public int DesignationID { get; set; }
        public string Designation { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public int ShiftID { get; set; }

        [Required]
        public int EmployeeType { get; set; }
        [Required]
        public string EmployeeCategory { get; set; }
        [Required]
        public int EMPStatus { get; set; }
        public int BranchID { get; set; }

        public string BankAccountNo { get; set; }

        [Required]
        public int PaymentMode { get; set; }
        [Required]
        public double BasicSalary { get; set; }

        public int SBUID { get; set; }
        public int Floor { get; set; }

        public string Room { get; set; }
        public int ShowAttendanceRpt { get; set; }
        public string NickName { get; set; }
        public string MobileNo { get; set; }

    }
}