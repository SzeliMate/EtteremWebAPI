using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using EtteremWebAPI.Controllers.NewFolder;
using EtteremWebAPI.Controllers.NewFolder.EtteremDTOs;

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
            [HttpPost("rendeles")]
            public object Rendeles(rendelesDTO register)
            {
                using var connector = new MySqlConnection(ConnectionString);
                connector.Open();
                string sql = @"INSERT INTO rendeles (Dish, Description, OrderTime, UpdateTime, VendegId) VALUES (@Dish, @Description, NOW(), NOW(), @VendegId)";
            using var cmd = new MySqlCommand(sql, connector);
            cmd.Parameters.AddWithValue("@Dish", register.Dish ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", register.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@VendegId", register.VendegId);
                connector.Close();
                return new { message = "Sikeres hozzáadás"};
 }
        [HttpPut("modosit")]
        public object UpdateBlogger([FromQuery] int id, [FromBody] updaterendelesdto updateRendelesDTos)
        {
            using var connector = new MySqlConnection(ConnectionString);
            connector.Open();
            string sql = @"UPDATE rendeles SET Dish=@Dish, Description=@Description, UpdateTime=NOW() WHERE Id=@Id";
            using var cmd = new MySqlCommand(sql, connector);
            cmd.Parameters.AddWithValue("@Dish", updateRendelesDTos.Dish ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", updateRendelesDTos.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", id);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return new { message = "Sikeres frissítés", result = updateRendelesDTos };
            }
            else
            {
                return new { message = "Sikertelen frissítés", result = updateRendelesDTos };
            }
        }

        [HttpDelete("torles")]
        public object RendelesTorles([FromBody] int id)
        {
            using var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            string sql = @"DELETE FROM rendeles WHERE Id = @Id";

            using var cmd = new MySqlCommand(sql, connector);
            cmd.Parameters.AddWithValue("@Id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            connector.Close();

            if (rowsAffected == 0)
            {
                return new { message = "Sikertelen törlés" };
            }

            return new { message = "Sikeres törlés" };
        }
    }
    }
