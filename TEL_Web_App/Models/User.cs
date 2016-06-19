using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string UserFullName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Enter User Name First")]
        public string UserName { get; set; }

       
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password First")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Salt { get; set; }

        public string UserSBUs { get; set; }

        public int EmployeeID { get; set; }
    }
}