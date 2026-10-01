using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EtteremWebAPI.Controllers.NewFolder;

namespace EtteremWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeatherForCast : ControllerBase
    {
        private string ConnectionString = "Server=localhost;Database=etterem;uid=root;password=;";

        [HttpGet("all")]
        public object GetRendelesall()
        {
            List<Rendelesall> result = new List<Rendelesall>();
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM rendeles", conn))
                {
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rendelesall e = new Rendelesall();
                            e.Id = reader.GetInt32("Id");
                            e.Dish = reader.GetString("Dish");
                            e.Description = reader.GetString("Description");
                            e.OrderTime = reader.GetDateTime("OrderTime");
                            e.UpdateTime = reader.GetDateTime("UpdateTime");
                            e.VendegId = reader.GetInt32("VendegId");
                            result.Add(e);
                        }
                    }
                }
            }
            return result;
        }

        [HttpGet("Id")]
        public object GetRendelesById(int id)
        {
            Rendelesall? result = null;
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM rendeles WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new Rendelesall();
                            result.Id = reader.GetInt32("Id");
                            result.Dish = reader.GetString("Dish");
                            result.Description = reader.GetString("Description");
                            result.OrderTime = reader.GetDateTime("OrderTime");
                            result.UpdateTime = reader.GetDateTime("UpdateTime");
                            result.VendegId = reader.GetInt32("VendegId");
                        }
                    }
                }
            }
            return result;
        }
    }
}