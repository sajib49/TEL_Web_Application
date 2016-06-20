using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEL_Web_App.Models;

namespace TEL_Web_App.Controllers
{
    public class UsersController : Controller
    {
        private ProjectDb db = new ProjectDb();
        // GET: Users
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User u)
        {
            User saltUser = new User();
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Salt FROM t_User WHERE UserName='" + u.UserName + "'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            saltUser.Salt = reader["Salt"].ToString();
                        }
                    }
                }
                
                connection.Close();
            }

            if (ModelState.IsValid)
            {
                //var userSalt = db.t_User.Where(x => x.UserName.Equals(u.UserName)).Select(x => x.Salt).FirstOrDefault();
                PDSAHash mph2 = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                string sHashValue = mph2.CreateHash(u.Password, saltUser.Salt);

                var aUser = db.t_User.Where(a => a.UserName.Equals(u.UserName) && a.Password.Equals(sHashValue)).FirstOrDefault();

                if (aUser != null)
                {
                    Session["LogedUserName"] = aUser.UserName.ToString();
                    Session["LogedUserPassword"] = aUser.Password.ToString();
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ModelState.AddModelError("User", "The user name or password is incorrect");
                    return View();
                }
            }
            return View(u);
        }

        public ActionResult Welcome()
        {
            if (Session["LogedUserName"] != null && Session["LogedUserPassword"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("LogIn");
        }
        
        public ActionResult LeaveApplication(string id)
        {
            Employee aEmployee = new Employee();
            List<Leave> leaves = new List<Leave>();

            using (SqlConnection connection = new SqlConnection(Connection.ConnectionString()))
            {
                connection.Open();
                using (SqlCommand command =new SqlCommand("SELECT EmployeeCode,EmployeeName,DesignationName,DepartmentName FROM t_User LEFT JOIN t_Employee ON t_User.EmployeeID = t_Employee.EmployeeID LEFT JOIN t_Department ON t_Employee.DepartmentID=t_Department.DepartmentID LEFT JOIN t_Designation ON t_Employee.DesignationID = t_Designation.DesignationID WHERE UserName='" +id + "'", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aEmployee.EmployeeCode = reader["EmployeeCode"].ToString();
                            aEmployee.EmployeeName = reader["EmployeeName"].ToString();
                            aEmployee.Designation = reader["DesignationName"].ToString();
                            aEmployee.Department = reader["DepartmentName"].ToString();
                        }
                    }
                }


                using (SqlCommand command = new SqlCommand("SELECT * FROM t_Leave", connection))
                {
                    using (SqlDataReader leaveReader = command.ExecuteReader())
                    {
                        while (leaveReader.Read())
                        {
                            Leave aLeave = new Leave
                            {
                                LeaveType = int.Parse(leaveReader["LeaveType"].ToString()),
                                LeaveTypeName = leaveReader["LeaveTypeName"].ToString(),
                                LeaveAllowed = int.Parse(leaveReader["LeaveAllowed"].ToString())
                            };
                            leaves.Add(aLeave);
                        }
                    }
                }
                connection.Close();
            }
            
            //ViewBag.LeaveList = new SelectList(leaves, "LeaveType", "LeaveTypeName");
            ViewBag.LeaveList = leaves;
            ViewBag.LeaveReasonList = new SelectList(new[]
            {
                new SelectListItem {Text = "Personal", Value = "1", Selected = true},
                new SelectListItem {Text = "Training", Value = "2"},
                new SelectListItem {Text = "Market Visit", Value = "3"},
                new SelectListItem {Text = "Foreign Tour", Value = "4"},
                new SelectListItem {Text = "Others", Value = "5"}
            }, "Text", "Text");
            ViewBag.aEmployee = aEmployee;
            //ViewBag.departmentWiseEmployees = new SelectList(FindEmployeesDepartmentWise(id), "EmployeeID", "EmployeeName");
            ViewBag.departmentWiseEmployees = FindEmployeesDepartmentWise(id);
                return View();
            }

        public List<Employee> FindEmployeesDepartmentWise(string id)
        { 
            List<Employee> employeeList = new List<Employee>();
            
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM t_Employee WHERE DepartmentID IN (SELECT DepartmentID FROM t_Employee WHERE EmployeeID IN (SELECT EmployeeID From t_User WHERE UserName='" + id + "'))", connection))
                {
                    using (SqlDataReader leaveReader = command.ExecuteReader())
                    {
                        while (leaveReader.Read())
                        {
                            Employee aEmployee = new Employee();
                            aEmployee.EmployeeID = int.Parse(leaveReader["EmployeeID"].ToString());
                            aEmployee.EmployeeName = leaveReader["EmployeeName"].ToString();
                            employeeList.Add(aEmployee);
                        }
                    }
                    connection.Close();
                }
            }
            return employeeList;
            
        }

        public JsonResult GetEmployeeByEmployeeId(int employeeId)
        {
            Employee anEmployee = new Employee();
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT EmployeeID,EmployeeCode,DesignationName,DepartmentName,Email,Mobile FROM t_Employee LEFT JOIN t_Department ON t_Employee.DepartmentID = t_Department.DepartmentID LEFT JOIN t_Designation ON t_Employee.DesignationID = t_Designation.DesignationID WHERE EmployeeID = '" + employeeId + "' ", connection))
                {

                    using (SqlDataReader employeeCounter = command.ExecuteReader())
                    {
                        while (employeeCounter.Read())
                        {

                            anEmployee.EmployeeID = int.Parse(employeeCounter["EmployeeID"].ToString());
                            //anEmployee.EmployeeName = employeeCounter["EmployeeName"].ToString();
                            anEmployee.EmployeeCode = employeeCounter["EmployeeCode"].ToString();
                            anEmployee.Department = employeeCounter["DepartmentName"].ToString();
                            anEmployee.Designation = employeeCounter["DesignationName"].ToString();
                            anEmployee.Email = employeeCounter["Email"].ToString();
                            anEmployee.MobileNo = employeeCounter["Mobile"].ToString();
                         }
                    }
                    connection.Close();
                }
            }
            return Json(anEmployee, JsonRequestBehavior.AllowGet);

        }


    }
}