﻿using System;
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
    public class UnitsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";
        public Units GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text; // Change to text for queries
            cmd.CommandText = "SELECT Id, Name FROM Units WHERE Id = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Units units = new Units();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    units.Id = (short)(getvalues[0]);
                    units.Name = getvalues[1].ToString();
                }
            }
            getvalues.Close();
            connect.Close();

            return units;
        }
        // GET: Units
        public async Task<IActionResult> Index()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text; // Change to text for queries
            cmd.CommandText = "SELECT Id, Name FROM Units";
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Units> units = new List<Units>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    units.Add(new Units()
                    {
                        Id = (short)(getvalues[0]),
                        Name = getvalues[1].ToString(),
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return View(units);
        }


        // GET: Units/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Units units)
        {
            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text; // Change to text for queries
                cmd.CommandText = "INSERT INTO Units (Name) VALUES (@Name)";
                cmd.Parameters.Add(new SqlParameter("@Name", units.Name));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }

            return View(units);
        }

        // GET: Units/Edit/5
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

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Name")] Units units)
        {
            if (id != units.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text; // Change to text for queries
                cmd.CommandText = "UPDATE Units SET Name = @Name WHERE Id = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Name", units.Name));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return RedirectToAction(nameof(Index));
            }
            var result = GetValuesofID(id);
            return View(result);
        }

        // GET: Units/Delete/5
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

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text; // Change to text for queries
            cmd.CommandText = "DELETE FROM Units WHERE Id = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction(nameof(Index));
        }

    }
}
