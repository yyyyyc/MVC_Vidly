# MVC_Vidly

1. Submit button

        public ActionResult EditCountry(int id, string SaveButton)
        {

            if (SaveButton != "Save")
            {
                ...
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
                ...
                cm.ExecuteNonQuery();

                //return View(new Country() {ID=ID, Name=Name, Population=Population, Area=Area });
                return Redirect("../../Home/ShowCountries");
            }
        }
        
        
        
