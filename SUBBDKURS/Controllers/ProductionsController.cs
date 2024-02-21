using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMS.Models;

namespace DBMS.Controllers
{
    public class ProductionsController : Controller
    {

        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";
        public Production GetValuesofID(short? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * From Production Where ID=@ID";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Production production = new Production();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    production.Id = (short)(getvalues[0]);
                    production.Product = (short)(getvalues[1]);
                    production.CountProduction = (float?)(getvalues[2]);
                    production.Date = (DateTime)(getvalues[3]);
                    production.Employee = (int?)(getvalues[4]);
                }
            }
            getvalues.Close();
            connect.Close();

            return production;

        }

        public List<Finproducts> GetValuesofFinproducts()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * from Finproducts";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Finproducts> finproducts = new List<Finproducts>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    finproducts.Add(new Finproducts()
                    {
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        Countproducts = (float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return finproducts;
        }

        public List<Employees> GetValuesofEmployees()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Employees";
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
                        Telephone = (getvalues[5]).ToString(),

                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return employees;
        }
        // GET: Productions
        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);
            Employees employees = new Employees();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Employees";
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
                        Telephone = (getvalues2[5]).ToString(),
                    });
                }
            }
            getvalues2.Close();




            Finproducts finproducts = new Finproducts();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "Select * from Finproducts";

            SqlDataReader getvalues3 = cmd3.ExecuteReader();
            List<Finproducts> finproducts1 = new List<Finproducts>();
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {
                    finproducts1.Add(new Finproducts()
                    {
                        Id = (short)getvalues3[0],
                        Name = getvalues3[1].ToString(),
                        Unit = (short)getvalues3[2],
                        Sum = Convert.ToDecimal(getvalues3[3]),
                        Countproducts = (float)getvalues3[4],
                    });
                }
            }
            getvalues3.Close();

            // Начинай отсюдова
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Production\r\n";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Production> productions = new List<Production>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Employees val in employees1)
                    {
                        foreach (Finproducts val2 in finproducts1)
                        {
                            if (val.Id == Convert.ToInt32(getvalues[4]) && val2.Id == (short)(getvalues[1]))
                            {
                                employees = val;
                                finproducts = val2;
                                productions.Add(new Production()
                                {
                                    Id = (short)(getvalues[0]),
                                    Product = (short)getvalues[1],
                                    CountProduction = (float?)getvalues[2],
                                    Date = (DateTime)getvalues[3],
                                    Employee = (int)getvalues[4],
                                    ProductNavigation = finproducts,
                                    EmployeeNavigation = employees,
                                });
                            }
                        }

                    }
                }
            }
            getvalues.Close();
            connect.Close();
            return View(productions);
        }


        // GET: Productions/Create
        public IActionResult Create()
        {
            var Product = GetValuesofFinproducts();
            var Employee = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(Employee, "Id", "Fullname");
            ViewData["Product"] = new SelectList(Product, "Id", "Name");
            var result = new Production { Date = DateTime.Now };
            return View(result);

        }

        // POST: Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Production production)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text;

                // Stored Procedure Query
                cmd.CommandText = @"
            BEGIN
                SET NOCOUNT ON;
                SET @a = 0;

                IF EXISTS (
                    SELECT *
                    FROM Ingredients
                    INNER JOIN Rawmaterials ON Ingredients.RawMaterials = Rawmaterials.ID
                    WHERE Rawmaterials.CountRawm < Ingredients.Countingred * @CountProduction
                        AND Ingredients.Product = @Product
                )
                BEGIN
                    SET @a = 1;
                END
                ELSE
                BEGIN
                    INSERT INTO Production (Product, CountProduction, Date, Employee)
                    VALUES (@Product, @CountProduction, @Date, @Employee);

                    DECLARE @сountPR real
                    DECLARE @ID int
                    DECLARE @SUMMA money

                    SELECT @сountPR = @CountProduction
                    SELECT @ID = @Product

                    SELECT @SUMMA =  SUM(Rawmaterials.Sum / Rawmaterials.CountRawm * Ingredients.Countingred * @сountPR)
                    FROM Rawmaterials
                    INNER JOIN Ingredients ON Rawmaterials.ID = Ingredients.RawMaterials
                    WHERE Ingredients.Product = @ID

                    UPDATE Finproducts
                    SET Countproducts = Countproducts + @сountPR, Sum = Sum + @SUMMA
                    WHERE ID = @ID

                    UPDATE Rawmaterials
                    SET Sum = Sum - (Sum / Rawmaterials.CountRawm * Ingredients.Countingred * @сountPR),
                        CountRawm = CountRawm - (Ingredients.Countingred * @сountPR)
                    FROM Rawmaterials
                    INNER JOIN Ingredients ON Rawmaterials.ID = Ingredients.RawMaterials
                    WHERE Ingredients.Product = @ID
                END
            END";

                cmd.Parameters.Add(new SqlParameter("@Product", production.Product));
                cmd.Parameters.Add(new SqlParameter("@CountProduction", production.CountProduction));
                cmd.Parameters.Add(new SqlParameter("@Date", production.Date));
                cmd.Parameters.Add(new SqlParameter("@Employee", production.Employee));

                SqlParameter p = new SqlParameter
                {
                    ParameterName = "@a",
                    SqlDbType = SqlDbType.Int,
                    Size = 1
                };
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);
                connect.Open();
                cmd.ExecuteNonQuery();

                var k = Convert.ToInt32((cmd.Parameters["@a"].Value));

                if (k == 0)
                {
                    connect.Close();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Massage = "Не хватает количества сырья!";
                }
            }

            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(production.Id);
            var EmployeeList = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(result);
        }

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            var EmployeeList = GetValuesofEmployees();
            if (result == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(result);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Product,CountProduction,Date,Employee")] Production production)
        {
            if (id != production.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "BEGIN\r\nUpdate Production set Product=@Product,CountProduction=@CountProduction,Date=@Date,Employee=@Employee\r\nWhere ID=@ID\r\nEND";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Product", production.Product));
                cmd.Parameters.Add(new SqlParameter("@CountProduction", production.CountProduction));
                cmd.Parameters.Add(new SqlParameter("@Date", production.Date));
                cmd.Parameters.Add(new SqlParameter("@Employee", production.Employee));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            var EmployeeList = GetValuesofEmployees();
            ViewData["Employee"] = new SelectList(EmployeeList, "Id", "Fullname", result.Employee);
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            return View(result);
        }

        // GET: Productions/Delete/5
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
            cmd.CommandText = "Select * from Finproducts/**/\r\nWhere ID=@ID\r\n";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Product));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Finproducts finproducts = new Finproducts();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    finproducts.Id = (short)getvalues[0];
                    finproducts.Name = getvalues[1].ToString();
                    finproducts.Unit = (short)getvalues[2];
                    finproducts.Sum = Convert.ToDecimal(getvalues[3]);
                    finproducts.Countproducts = (float)getvalues[4];
                }
            }
            getvalues.Close();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Employees";
            cmd2.Parameters.Add(new SqlParameter("@ID", result.Employee));

            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            Employees employees = new Employees();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    employees.Id = (int)getvalues2[0];
                    employees.Fullname = (getvalues2[1]).ToString();
                    employees.Position = (short)getvalues2[2];
                    employees.Salary = Convert.ToDecimal(getvalues2[3]);
                    employees.Address = (getvalues2[4]).ToString();
                    employees.Telephone = (getvalues2[5]).ToString();
                }
            }
            getvalues2.Close();
            connect.Close();

            if (result == null)
            {
                return NotFound();
            }
            result.ProductNavigation = finproducts;
            result.EmployeeNavigation = employees;
            return View(result);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete From Production Where ID=@ID\r\n";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }

    }
}