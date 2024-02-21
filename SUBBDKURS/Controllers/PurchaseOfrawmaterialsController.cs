using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMS.Models;

namespace DBMS.Controllers
{
    public class PurchaseOfrawmaterialsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";
        public PurchaseOfrawmaterials GetValuesofID(short? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * From PurchaseOfrawmaterials\r\nWhere ID=@ID\r\n";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            PurchaseOfrawmaterials purchaseOfrawmaterials = new PurchaseOfrawmaterials();

            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {


                    purchaseOfrawmaterials.Id = (short)(getvalues[0]);
                    purchaseOfrawmaterials.RawMaterials = (short)(getvalues[1]);
                    purchaseOfrawmaterials.CountPur = (float?)(getvalues[2]);
                    purchaseOfrawmaterials.Sum = (decimal)(getvalues[3]);
                    purchaseOfrawmaterials.Date = (DateTime)(getvalues[4]);
                    purchaseOfrawmaterials.Employee = (int?)(getvalues[5]);
                }
            }
            getvalues.Close();
            connect.Close();

            return purchaseOfrawmaterials;

        }

        public List<Rawmaterials> GetValuesofRawmaterials()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * From Rawmaterials";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Rawmaterials> rawmaterials = new List<Rawmaterials>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    rawmaterials.Add(new Rawmaterials()
                    {
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        CountRawm = (float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return rawmaterials;
        }

        public List<Employees> GetValuesofEmployees()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * From Employees";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    employees.Add(new Employees()
                    {

                        Id = (int)getvalues[0],
                        Fullname = getvalues[1].ToString(),
                        Position = (short?)getvalues[2],
                        Salary = Convert.ToDecimal(getvalues[3]),
                        Address = (getvalues[4]).ToString(),
                        Telephone = (getvalues[4]).ToString(),

                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return employees;
        }



        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);
            Employees employees = new Employees();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * From Employees";
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Employees> employees1 = new List<Employees>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    employees1.Add(new Employees()
                    {
                        Id = Convert.ToInt32(getvalues2[0]),
                        Fullname = getvalues2[1].ToString(),
                        Position = (short)getvalues2[2],
                        Salary = Convert.ToDecimal(getvalues2[3]),
                        Address = (getvalues2[4]).ToString(),
                        Telephone = (getvalues2[4]).ToString(),
                    });
                }
            }
            getvalues2.Close();


            Rawmaterials rawmaterials = new Rawmaterials();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "Select * From Rawmaterials";

            SqlDataReader getvalues3 = cmd3.ExecuteReader();
            List<Rawmaterials> rawmaterials1 = new List<Rawmaterials>();
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {
                    rawmaterials1.Add(new Rawmaterials()
                    {
                        Id = (short)getvalues3[0],
                        Name = getvalues3[1].ToString(),
                        Unit = (short)getvalues3[2],
                        Sum = Convert.ToDecimal(getvalues3[3]),
                        CountRawm = (float)getvalues3[4],
                    });
                }
            }
            getvalues3.Close();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * From PurchaseOfrawmaterials\r\n";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<PurchaseOfrawmaterials> purchaseOfrawmaterials = new List<PurchaseOfrawmaterials>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Employees val in employees1)
                    {
                        foreach (Rawmaterials val2 in rawmaterials1)
                        {




                            if (val.Id == Convert.ToInt32(getvalues[5]) && val2.Id == (short)(getvalues[1]))
                            {
                                employees = val;
                                rawmaterials = val2;

                                purchaseOfrawmaterials.Add(new PurchaseOfrawmaterials()
                                {

                                    Id = (short)(getvalues[0]),
                                    RawMaterials = (short)getvalues[1],
                                    CountPur = (float)(getvalues[2]),
                                    Sum = Convert.ToDecimal(getvalues[3]),
                                    Date = (DateTime)getvalues[4],
                                    Employee = (int)getvalues[5],

                                    RawMaterialsNavigation = rawmaterials,
                                    EmployeeNavigation = employees,
                                });
                            }
                        }

                    }
                }
            }
            getvalues.Close();
            connect.Close();
            return View(purchaseOfrawmaterials);
        }



        public IActionResult Create()
        {

            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();

            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            var result = new PurchaseOfrawmaterials { Date = DateTime.Now };
            return View(result);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create([FromForm] PurchaseOfrawmaterials purchaseOfrawmaterials)
        {
            if (ModelState.IsValid)
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    var cmd = new SqlCommand("BEGIN\r\n  SET NOCOUNT ON;\r\n\r\n  IF @Sum > (SELECT Budgetamount FROM Budgets WHERE ID = 1002)\r\n    SET @a = 1;\r\n  ELSE\r\n  BEGIN\r\n    INSERT INTO PurchaseOfrawmaterials (RawMaterials, CountPur, Sum, Date, Employee)\r\n    VALUES (@RawMaterials, @CountPur, @Sum, @Date, @Employee);\r\n\r\n    UPDATE Rawmaterials\r\n    SET Sum = Sum + @Sum,\r\n        CountRawm = CountRawm + @CountPur\r\n    WHERE ID = @RawMaterials;\r\n\r\n    UPDATE Budgets\r\n    SET Budgetamount = Budgetamount - @Sum;\r\n\r\n    SET @a = 0;\r\n  END;\r\nEND", connection)
                    {
                        CommandType = CommandType.Text
                    };

                    cmd.Parameters.AddWithValue("@RawMaterials", purchaseOfrawmaterials.RawMaterials);
                    cmd.Parameters.AddWithValue("@CountPur", purchaseOfrawmaterials.CountPur);
                    cmd.Parameters.AddWithValue("@Sum", purchaseOfrawmaterials.Sum);
                    cmd.Parameters.AddWithValue("@Date", purchaseOfrawmaterials.Date);
                    cmd.Parameters.AddWithValue("@Employee", purchaseOfrawmaterials.Employee);

                    var p = cmd.Parameters.Add("@a", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;

                    await connection.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();

                    var result = (int)p.Value;

                    if (result == 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Massage = "Не хватает бюджета для закупки!";
                    }
                }
            }

            var employeeList = GetValuesofEmployees();
            var rawMaterialList = GetValuesofRawmaterials();
            var resultData = GetValuesofID(purchaseOfrawmaterials.Id);

            ViewData["Employee"] = new SelectList(employeeList, "Id", "Fullname", purchaseOfrawmaterials.Employee);
            ViewData["RawMaterials"] = new SelectList(rawMaterialList, "Id", "Name", purchaseOfrawmaterials.RawMaterials);

            return View(resultData);
        }

        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();
            var result = GetValuesofID(id);

            if (result == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            return View(result);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,RawMaterials,CountPur,Sum,Date,Employee")] PurchaseOfrawmaterials purchaseOfrawmaterials)
        {
            if (id != purchaseOfrawmaterials.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Begin\r\nUpdate PurchaseOfrawmaterials set RawMaterials=@RawMaterials,CountPur=@CountPur,Sum=@Sum,Date=@Date,Employee=@Employee\r\nWhere ID=@ID\r\nEnd";

                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@RawMaterials", purchaseOfrawmaterials.RawMaterials));
                cmd.Parameters.Add(new SqlParameter("@CountPur", purchaseOfrawmaterials.CountPur));
                cmd.Parameters.Add(new SqlParameter("@Sum", purchaseOfrawmaterials.Sum));
                cmd.Parameters.Add(new SqlParameter("@Date", purchaseOfrawmaterials.Date));
                cmd.Parameters.Add(new SqlParameter("@Employee", purchaseOfrawmaterials.Employee));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var Employee = GetValuesofEmployees();
            var Rawmaterial = GetValuesofRawmaterials();
            var result = GetValuesofID(purchaseOfrawmaterials.Id);
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname", purchaseOfrawmaterials.Employee);
            ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name", purchaseOfrawmaterials.RawMaterials);
            return View(result);
        }


        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = GetValuesofID(id);
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Begin\r\nSELECT * From Employees\r\nWhere Employees.ID=@ID\r\nEnd";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Employee));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Employees employees = new Employees();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    employees.Id = Convert.ToInt32(getvalues[0]);
                    employees.Fullname = getvalues[1].ToString();
                    employees.Position = (short?)getvalues[2];
                    employees.Salary = Convert.ToDecimal(getvalues[3]);
                    employees.Address = (getvalues[4]).ToString();
                    employees.Telephone = (getvalues[4]).ToString();
                }
            }
            getvalues.Close();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * From Rawmaterials\r\nWhere ID=@ID\r\n";
            cmd2.Parameters.Add(new SqlParameter("@ID", result.RawMaterials));

            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            Rawmaterials rawmaterials = new Rawmaterials();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    rawmaterials.Id = (short)getvalues2[0];
                    rawmaterials.Name = getvalues2[1].ToString();
                    rawmaterials.Unit = (short)getvalues2[2];
                    rawmaterials.Sum = Convert.ToDecimal(getvalues2[3]);
                    rawmaterials.CountRawm = (float)getvalues2[4];
                }
            }
            getvalues2.Close();
            connect.Close();
            if (result == null)
            {
                return NotFound();
            }




            result.EmployeeNavigation = employees;
            result.RawMaterialsNavigation = rawmaterials;
            return View(result);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete From PurchaseOfrawmaterials\r\nWhere ID=@ID\r\n";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
