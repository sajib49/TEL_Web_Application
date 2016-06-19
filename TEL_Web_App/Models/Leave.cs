using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public class Leave
    {
        public int LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeaveAllowed { get; set; }
    }
}