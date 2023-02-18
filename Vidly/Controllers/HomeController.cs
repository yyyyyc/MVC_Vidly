using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        //public ActionResult YC ()
        //{
        //    ViewBag.Message = "YC Page";

        //    SqlConnection cn = new SqlConnection();
        //    cn.ConnectionString = @"Server=.\SQLEXPRESS;Database=ycdb;Trusted_Connection=True;";
        //    SqlCommand cm = new SqlCommand();
        //    cm.CommandType = CommandType.Text;
        //    cm.CommandText = "Select * From Countries";
        //    cm.Connection = cn;
        //    cn.Open();

        //    List<Country> Countries = new List<Country>();
        //    SqlDataReader dr = cm.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        Countries.Add(new Country() { Name = dr["Name"].ToString(), Area = (int)dr["Area"], Population = (int)dr["Population"] });
        //    }
        //    cn.Close();
            
        //    ViewBag.Countries = Countries;

        //    var Country = new Country() { Name = "C1", Area = 100000, Population = 5000000 };
        //    return View(Country);
        //}

        public ActionResult ShowCountries()
        {
            ViewBag.Message = "Show Countries Page";

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Server=.\SQLEXPRESS;Database=ycdb;Trusted_Connection=True;";
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = "Select * From Countries";
            cm.Connection = cn;
            cn.Open();

            List<Country> Countries = new List<Country>();
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Countries.Add(new Country() { 
                    Name = dr["Name"].ToString(), 
                    Area = (int)dr["Area"], 
                    Population = (int)dr["Population"],
                    ID = (int)dr["ID"],
                });
            }
            cn.Close();

            return View(Countries);

        }

        public ActionResult EditCountry(int id, string SaveButton)
        {

            if (SaveButton != "Save")
            {

                ViewBag.Message = "Edit Country";
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Server=.\SQLEXPRESS;Database=ycdb;Trusted_Connection=True;";
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = $"Select Top 1 * From Countries where id={id}";
                cm.Connection = cn;
                cn.Open();

                Country country = new Country();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    country.Name = dr["Name"].ToString();
                    country.Area = (int)dr["Area"];
                    country.Population = (int)dr["Population"];
                }
                cn.Close();

                return View(country);
            }
            else
            {

                int ID = int.Parse(Request.Form ["ID"]);
                string Name = Request.Form["Name"];
                int Population = int.Parse(Request.Form["Population"]);
                int Area = int.Parse(Request.Form["Area"]);

                string SqlStr = $"Update Countries Set Name='{Name}', Population={Population}, Area={Area} Where ID={ID}";

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Server=.\SQLEXPRESS;Database=ycdb;Trusted_Connection=True;";
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = SqlStr;

                cm.Connection = cn;
                cn.Open();
                cm.ExecuteNonQuery();

                //return View(new Country() {ID=ID, Name=Name, Population=Population, Area=Area });
                return Redirect("../../Home/ShowCountries");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}