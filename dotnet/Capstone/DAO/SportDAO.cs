using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class SportDAO : ISportDAO
    {
        private readonly string connectionString;

        private string sqlGetSports = "SELECT * FROM sports ORDER BY sport_name";

        public SportDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Sport> GetSports()
        {
            List<Sport> sports = new List<Sport>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetSports, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Sport sport = ConvertReaderToSport(reader);
                        sports.Add(sport);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sports;
        }
        private Sport ConvertReaderToSport(SqlDataReader reader)
        {
            Sport sport = new Sport();
            sport.SportId = Convert.ToInt32(reader["sport_id"]);
            sport.SportName = Convert.ToString(reader["sport_name"]);
            return sport;
        }
    }
}
