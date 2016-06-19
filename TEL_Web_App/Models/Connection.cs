using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEL_Web_App.Models
{
    public static class Connection
    {
        public static string ConnectionString()
        {
            return "Data Source=TELSVRMIS01;Initial Catalog=TELSysDB;User Id=telSysUser;Password=telmis";
        }
    }
}