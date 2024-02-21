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
    public class PositionsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";
        public Positions GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            string query = "SELECT Id, Position FROM Positions WHERE Id = @ID";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Positions positions = new Positions();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    positions.Id = (short)(getvalues["Id"]);
                    positions.Position = getvalues["Position"].ToString();
                }
            }
            getvalues.Close();
            connect.Close();
            return positions;
        }
        // GET: Positions
        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);
            string query = "SELECT Id, Position FROM Positions";
            SqlCommand cmd = new SqlCommand(query, connect);
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Positions> positions = new List<Positions>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    positions.Add(new Positions()
                    {
                        Id = (short)(getvalues["Id"]),
                        Position = getvalues["Position"].ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return View(positions);
        }


        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position")] Positions positions)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                string query = "INSERT INTO Positions (Position) VALUES (@Name)";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@Name", positions.Position));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            return View(positions);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(short? id)
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

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Position")] Positions positions)
        {
            if (id != positions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                string query = "UPDATE Positions SET Position = @Name WHERE Id = @ID";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Name", positions.Position));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            return View(positions);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(short? id)
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

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            string query = "DELETE FROM Positions WHERE Id = @ID";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }

    }
}
