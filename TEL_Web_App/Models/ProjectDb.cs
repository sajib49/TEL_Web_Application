using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public class ProjectDb:DbContext
    {
        public ProjectDb() : base("User_ConnectionString")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<User> t_User { get; set; }
        //public DbSet<Employee> t_Employee { get; set; }
    }
}