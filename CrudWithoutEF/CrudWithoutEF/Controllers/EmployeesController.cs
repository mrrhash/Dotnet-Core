#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudWithoutEF.Data;
using CrudWithoutEF.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudWithoutEF.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Employees
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();      
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
               SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("AllEmployees",sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDataAdapter.Fill(dataTable);
            }
            return View(dataTable);
        }



        // GET: Employees/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            Employee employee = new Employee(); 
            if(id > 0)
            
                employee = fetchemployebyID(id);
            
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("ID,Name,Mobile,Address,Designation")] Employee employee)
        {


            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("EmployeesAddOrEdit",sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", employee.ID);
                    cmd.Parameters.AddWithValue("Name", employee.Name);
                    cmd.Parameters.AddWithValue("Mobile", employee.Mobile);
                    cmd.Parameters.AddWithValue("Address", employee.Address);
                    cmd.Parameters.AddWithValue("Designation", employee.Designation);
                    cmd.ExecuteNonQuery(); 
                }
                return RedirectToAction(nameof(Index));
            }
                return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            Employee employee = fetchemployebyID(id);

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DeleteEmployee", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
               
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public Employee fetchemployebyID(int? id)
        {
            Employee employee = new Employee();
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EmployeewithID", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("ID",id);
                sqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count == 1)
                {
                    employee.ID = Convert.ToInt32(dataTable.Rows[0]["ID"].ToString());
                    employee.Name = dataTable.Rows[0]["Name"].ToString();
                    employee.Address = dataTable.Rows[0]["Address"].ToString();
                    employee.Mobile = dataTable.Rows[0]["Mobile"].ToString();
                    employee.Designation = dataTable.Rows[0]["Designation"].ToString();
                }
                return employee;
            }
            

        }
       
    }
}
