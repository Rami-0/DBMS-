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
    public class IngredientsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=SUBD;User ID=sa;Password=123; TrustServerCertificate=True";
        public Ingredients GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * From Ingredients Where ID=@ID";
            // cmd.CommandText = "SELECT [ID], [Product], [RawMaterials], [Countingred] FROM [Ingredients] WHERE [Product] = @ProductID";
            cmd.Parameters.Add(new SqlParameter("@ID", Id));
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Ingredients ingredients = new Ingredients();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    ingredients.Id = (short)(getvalues[0]);
                    ingredients.Product = (short)(getvalues[1]);
                    ingredients.RawMaterials = (short?)(getvalues[2]);
                    ingredients.Countingred = (float)(getvalues[3]);
                }
            }
            getvalues.Close();
            connect.Close();

            return ingredients;

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
        public List<Finproducts> GetValuesofFinproductsID(int ID)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * from Finproducts Where ID=@ID";
            cmd2.Parameters.Add(new SqlParameter("@ID", ID));
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

        public List<Rawmaterials> GetValuesofRawmaterials()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * From Rawmaterials"; //все сырье
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

        // GET: Ingredients
        public async Task<IActionResult> Index(int SearchString)
        {
            connect = new SqlConnection(connectionstring);
            Finproducts finproducts = new Finproducts();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select * from Finproducts"; // все продукты
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Finproducts> finproducts1 = new List<Finproducts>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    finproducts1.Add(new Finproducts()
                    {
                        Id = (short)getvalues2[0],
                        Name = getvalues2[1].ToString(),
                        Unit = (short)getvalues2[2],
                        Sum = Convert.ToDecimal(getvalues2[3]),
                        Countproducts = (float)getvalues2[4],
                    });
                }
            }
            getvalues2.Close();


            Rawmaterials rawmaterials = new Rawmaterials();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "Select * From Rawmaterials"; // все сырье

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
            cmd.CommandText = "Select * From Ingredients";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Ingredients> ingredients = new List<Ingredients>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Finproducts val in finproducts1)
                    {
                        foreach (Rawmaterials val2 in rawmaterials1)
                        {
                            if (val.Id == (short?)(getvalues[1]) && val2.Id == (short?)(getvalues[2]))
                            {
                                finproducts = val;
                                rawmaterials = val2;
                                ingredients.Add(new Ingredients()
                                {
                                    Id = (short)(getvalues[0]),
                                    Product = (short)(getvalues[1]),
                                    RawMaterials = (short)getvalues[2],
                                    Countingred = (float)(getvalues[3]),
                                    ProductNavigation = finproducts,
                                    RawMaterialsNavigation = rawmaterials,
                                });
                            }
                        }

                    }
                }
            }

            if (SearchString == 0)
            {
                getvalues.Close();

                connect.Close();
                var FinproductsList = GetValuesofFinproducts();
                ViewData["Product"] = new SelectList(FinproductsList, "Id", "Name");

                return View(ingredients);
            }
            else
            {
                getvalues.Close(); //Затем закрывается ранее открытый объект getvalues
                SqlCommand cmdf = new SqlCommand(); //Создается новый объект SqlCommand, связанный с текущим подключением к базе данных
                cmdf.Connection = connect;
                cmdf.CommandType = System.Data.CommandType.Text;
                cmdf.CommandText = "Select * From Ingredients Where Ingredients.Product=@Search";
                cmdf.Parameters.Add(new SqlParameter("@Search", SearchString));  // Параметр "@Search"  использован в теле хранимой процедуры для фильтрации данных в соответствии со значением
                SqlDataReader getvalues4 = cmdf.ExecuteReader();
                List<Ingredients> ingredients1 = new List<Ingredients>();
                if (getvalues4.HasRows)
                {
                    while (getvalues4.Read())
                    {
                        foreach (Finproducts val in finproducts1)
                        {
                            foreach (Rawmaterials val2 in rawmaterials1)
                            {
                                if (val.Id == (short?)(getvalues4[1]) && val2.Id == (short?)(getvalues4[2]))
                                {
                                    finproducts = val;
                                    rawmaterials = val2;
                                    ingredients1.Add(new Ingredients()
                                    {
                                        Id = (short)(getvalues4[0]),
                                        Product = (short)(getvalues4[1]),
                                        RawMaterials = (short)getvalues4[2],
                                        Countingred = (float)(getvalues4[3]),
                                        ProductNavigation = finproducts,
                                        RawMaterialsNavigation = rawmaterials,
                                    });
                                }
                            }

                        }
                    }
                }
                getvalues4.Close();
                connect.Close();
                var FinproductsList = GetValuesofFinproducts();
                ViewData["Product"] = new SelectList(FinproductsList, "Id", "Name");

                return View(ingredients1);
            }

        }


        // GET: Ingredients/Create
        public IActionResult Create(int ID)
        {
            var Product = GetValuesofFinproducts();
            var ProductID = GetValuesofFinproductsID(ID);
            var Rawmaterial = GetValuesofRawmaterials();
            if (ID == 0)
            {
                ViewData["Product"] = new SelectList(Product, "Id", "Name");
                ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            }
            else
            {
                ViewData["Product"] = new SelectList(Product.Where(e => e.Id == ID), "Id", "Name");
                ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            }


            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,RawMaterials,Countingred")] Ingredients ingredients)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ////создаем соединение с базой данных
                    connect = new SqlConnection(connectionstring);
                    //создаем объект команды SQL для вызова хранимой процедуры в базе данных
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Ingredients(Product,RawMaterials,Countingred) Values(@Product,@RawMaterials,@Countingred)";
                    ////добавляем параметры в команду SQL для сохранения значений ингредиентов в базе данных
                    cmd.Parameters.Add(new SqlParameter("@Product", ingredients.Product));
                    cmd.Parameters.Add(new SqlParameter("@RawMaterials", ingredients.RawMaterials));
                    cmd.Parameters.Add(new SqlParameter("@Countingred", ingredients.Countingred));
                    //открываем соединение с базой данных и выполним команду SQL для вставки данных
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    //закрываем соединение с базой данных
                    connect.Close();
                    //получаем идентификатор продукта
                    int ID = Convert.ToInt32(ingredients.Product);
                    //перенаправляем пользователя на страницу Index с указанием идентификатора продукта
                    return RedirectToAction("Index", new { searchString = ID });
                }
            }
            catch (SqlException ex)
            {
                // Формирование текста ошибки с указанием значения ключа, вызвавшего ошибку
                string errorMessage = $"Error: This Raw material is already added";

                // Сохранение сообщения об ошибке в TempData
                TempData["ErrorMessage"] = errorMessage;
            }
            //для отображения представления
            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(ingredients.Id);
            var RawMaterialstlist = GetValuesofRawmaterials();
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }



        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            if (result == null)
            {
                return NotFound();
            }

            int ProductID = (int)result.Product;
            var RawMaterialstlist = GetValuesofRawmaterials();
            var Product = GetValuesofFinproducts();

            ViewData["Product"] = new SelectList(Product.Where(e => e.Id == ProductID), "Id", "Name");
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Product,RawMaterials,Countingred")] Ingredients ingredients)
        {
            if (id != ingredients.Id)
            {
                return NotFound();
            }
            var result = GetValuesofID(id);
            if (ModelState.IsValid)
            {


                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Update Ingredients set Product=@Product,RawMaterials=@RawMaterials,Countingred=@Countingred Where ID=@ID"; //ОбновлениеИнгредиенты
                                                                                                                                              //отвечает за добавление параметров в SQL
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Product", ingredients.Product));
                cmd.Parameters.Add(new SqlParameter("@RawMaterials", ingredients.RawMaterials));
                cmd.Parameters.Add(new SqlParameter("@Countingred", ingredients.Countingred));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                int ID = Convert.ToInt32(ingredients.Product);
                return RedirectToAction("Index", new { searchString = ID });

            }
            var Productlist = GetValuesofFinproducts();
            var RawMaterialstlist = GetValuesofRawmaterials();

            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // GET: Ingredients/Delete/5
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
            cmd.CommandText = "Select * from Finproducts Where ID=@ID"; //все продукты id=@id
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
            cmd2.CommandText = "Select * From Rawmaterials Where ID=@ID"; //сырье
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
            result.ProductNavigation = finproducts;
            result.RawMaterialsNavigation = rawmaterials;
            return View(result);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var result = GetValuesofID(id);
            int ID = (int)result.Product;
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete From Ingredients Where ID=@ID";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction("Index", new { searchString = ID });
        }
    }
}
