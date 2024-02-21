using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMS.Models;

namespace DBMS.Controllers
{
    public class EmployeesController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";

        public Employees GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Employees WHERE Id = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Employees employees = new Employees();
            DBMSContext sUBDContext = new DBMSContext();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    employees.Id = Convert.ToInt32(getvalues[0]);
                    employees.Fullname = (getvalues[1]).ToString();
                    employees.Position = (short?)(getvalues[2]);
                    employees.Salary = Convert.ToDecimal(getvalues[3]);
                    employees.Address = (getvalues[4]).ToString();
                    employees.Telephone = (getvalues[5]).ToString();
                }
            }
            getvalues.Close();
            connect.Close();

            return employees;
        }

        public List<Positions> GetValuesofPositions()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Positions";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Positions> positions = new List<Positions>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    positions.Add(new Positions()
                    {
                        Id = (short)getvalues[0],
                        Position = getvalues[1].ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return positions;
        }

        // ... (other methods remain the same)

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);

            Positions positions = new Positions();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Positions";
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Positions> positions1 = new List<Positions>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    positions1.Add(new Positions()
                    {
                        Id = (short)getvalues2[0],
                        Position = getvalues2[1].ToString(),
                    });
                }
            }
            getvalues2.Close();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Employees";

            SqlDataReader getvalues = cmd.ExecuteReader();

            List<Employees> employees = new List<Employees>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Positions val in positions1)
                    {
                        if (val.Id == (short?)(getvalues[2]))
                        {
                            positions = val;
                            employees.Add(new Employees()
                            {
                                Id = Convert.ToInt32(getvalues[0]),
                                Fullname = (getvalues[1]).ToString(),
                                Position = (short?)(getvalues[2]),
                                Salary = Convert.ToDecimal(getvalues[3]),
                                Address = (getvalues[4]).ToString(),
                                Telephone = (getvalues[5]).ToString(),
                                PositionNavigation = positions,
                            });
                        }
                    }
                }
            }
            getvalues.Close();
            connect.Close();
            return View(employees);
        }

        // ... (remaining methods remain the same)

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = GetValuesofID(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // ... (remaining methods remain the same)

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            connect = new SqlConnection(connectionstring);
            var result = GetValuesofID(id);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Positions WHERE Id = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Position));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Positions positions = new Positions();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    positions.Id = (short)getvalues[0];
                    positions.Position = getvalues[1].ToString();
                }
            }
            getvalues.Close();
            connect.Close();
            if (result == null)
            {
                return NotFound();
            }
            result.PositionNavigation = positions;
            return View(result);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Employees WHERE Id = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }

        // ... (remaining methods remain the same)

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var posintionslist = GetValuesofPositions();
            var result = GetValuesofID(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewData["Position"] = new SelectList(posintionslist, "Id", "Position", result.Position);
            return View(result);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fullname,Position,Salary,Address,Telephone")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Employees SET Fullname = @Fullname, Position = @Position, Salary = @Salary, Address = @Address, Telephone = @Telephone WHERE Id = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Fullname", employees.Fullname));
                cmd.Parameters.Add(new SqlParameter("@Position", employees.Position));
                cmd.Parameters.Add(new SqlParameter("@Salary", employees.Salary));
                cmd.Parameters.Add(new SqlParameter("@Address", employees.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", employees.Telephone));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var posintionslist = GetValuesofPositions();
            var result = GetValuesofID(id);
            ViewData["Position"] = new SelectList(posintionslist, "Id", "Position", result.Position);
            return View(result);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Positions";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Positions> positions = new List<Positions>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    positions.Add(new Positions()
                    {
                        Id = (short)getvalues[0],
                        Position = getvalues[1].ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            ViewData["Position"] = new SelectList(positions, "Id", "Position");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fullname,Position,Salary,Address,Telephone")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO Employees (Fullname, Position, Salary, Address, Telephone) VALUES (@Fullname, @Position, @Salary, @Address, @Telephone)";
                cmd.Parameters.Add(new SqlParameter("@Fullname", employees.Fullname));
                cmd.Parameters.Add(new SqlParameter("@Position", employees.Position));
                cmd.Parameters.Add(new SqlParameter("@Salary", employees.Salary));
                cmd.Parameters.Add(new SqlParameter("@Address", employees.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", employees.Telephone));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var posintionslist = GetValuesofPositions();
            ViewData["Position"] = new SelectList(posintionslist, "Id", "Position", employees.Position);
            return View(employees);
        }
    }

}


