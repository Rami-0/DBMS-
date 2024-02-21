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
    public class BudgetsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";

        public Budgets GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            string sqlQuery = $"SELECT * FROM Budgets WHERE Id = @ID";
            SqlCommand cmd = new SqlCommand(sqlQuery, connect);
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Budgets budgets1 = new Budgets();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    budgets1.Id = Convert.ToInt32(getvalues["Id"]);
                    budgets1.Budgetamount = Convert.ToDecimal(getvalues["Budgetamount"]);
                    budgets1.SalePercentage = (float?)(getvalues["SalePercentage"]);
                    budgets1.Bonus = (float?)(getvalues["Bonus"]);
                }
            }
            getvalues.Close();
            connect.Close();
            return budgets1;
        }

        public async Task<IActionResult> Index()
        {
            List<Budgets> budgets = new List<Budgets>();
            connect = new SqlConnection(connectionstring);
            string sqlQuery = "SELECT * FROM Budgets";
            SqlCommand cmd = new SqlCommand(sqlQuery, connect);
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();

            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    budgets.Add(new Budgets()
                    {
                        Id = Convert.ToInt32(getvalues["Id"]),
                        Budgetamount = Convert.ToDecimal(getvalues["Budgetamount"]),
                        SalePercentage = (float?)(getvalues["SalePercentage"]),
                        Bonus = (float?)(getvalues["Bonus"]),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return View(budgets);
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Budgetamount,SalePercentage,Bonus")] Budgets budgets)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                string sqlQuery = "INSERT INTO Budgets (Budgetamount, SalePercentage, Bonus) VALUES (@Summa, @SalePerc, @Bon)";
                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add(new SqlParameter("@Summa", budgets.Budgetamount));
                cmd.Parameters.Add(new SqlParameter("@SalePerc", budgets.SalePercentage));
                cmd.Parameters.Add(new SqlParameter("@Bon", budgets.Bonus));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var result = GetValuesofID(budgets.Id);
                return View(result);
            }
        }


        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var result = GetValuesofID(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Budgets budgets)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                string sqlQuery = "UPDATE Budgets SET Budgetamount = @Summa, SalePercentage = @SalePers, Bonus = @Bon WHERE Id = @ID";
                SqlCommand cmd = new SqlCommand(sqlQuery, connect);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Summa", budgets.Budgetamount));
                cmd.Parameters.Add(new SqlParameter("@SalePers", budgets.SalePercentage));
                cmd.Parameters.Add(new SqlParameter("@Bon", budgets.Bonus));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var result = GetValuesofID(id);
                return View(result);
            }
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = GetValuesofID(id);
            return View(result);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            connect = new SqlConnection(connectionstring);
            string sqlQuery = "DELETE FROM Budgets WHERE Id = @ID";
            SqlCommand cmd = new SqlCommand(sqlQuery, connect);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
