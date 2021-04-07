using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class TournamentSqlDAO : ITournamentDAO
    {
        private readonly string connectionString;

        public TournamentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        private string sqlGetTournaments = "SELECT * FROM tournaments t " +
            "JOIN users u ON u.user_id = t.creator_id " +
            "JOIN sports s ON s.sport_id = t.sport_id";

        private string sqlCreateTournament = " INSERT INTO tournaments(creator_id , tournament_name , sport_id ) VALUES(" +
            "(SELECT user_id FROM users WHERE username = (@creatorUsername)) " +
            ", (@tournamentName), " +
"(SELECT sport_id FROM sports WHERE sport_name = (@sportName)));";

        private string sqlGetTournament = " SELECT * FROM tournaments t " +
        "JOIN users u ON u.user_id = t.creator_id" +
        "JOIN sports s ON s.sport_id = t.sport_id" +
        "WHERE tournament_id = (@tournament_id));";

        public List<Tournament> GetTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetTournaments, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Tournament tournament = ConvertReaderToTournament(reader);
                        tournaments.Add(tournament);

                    }
                    foreach (Tournament tournament in tournaments)
                    {
                        tournament.NumberOfParticipants = GetNumberOfParticipants(tournament.TournamentId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tournaments;
        }



        private int GetNumberOfParticipants(int tour_id)
        {
            int result = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM participants WHERE tournament_id = (@tour_id);", conn);
                    cmd.Parameters.AddWithValue("@tour_id", tour_id);

                    result = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        private Tournament ConvertReaderToTournament(SqlDataReader reader)
        {
            Tournament tournament = new Tournament();
            tournament.TournamentId = Convert.ToInt32(reader["tournament_id"]);
            tournament.CreatorId = Convert.ToInt32(reader["creator_id"]);
            tournament.CreatorUsername = Convert.ToString(reader["username"]);
            tournament.TournamentName = Convert.ToString(reader["tournament_name"]);
            tournament.SportId = Convert.ToInt32(reader["sport_id"]);
            tournament.SportName = Convert.ToString(reader["sport_name"]);
            tournament.TourComplete = Convert.ToBoolean(reader["tour_complete"]);
            return tournament;
        }

        public bool CreateTournament(Tournament tournament)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlCreateTournament, conn);
                    cmd.Parameters.AddWithValue("@tournamentName", tournament.TournamentName);
                    cmd.Parameters.AddWithValue("@sportName", tournament.SportName);
                    cmd.Parameters.AddWithValue("@creatorUsername", tournament.CreatorUsername);


                    int rowsEffected = cmd.ExecuteNonQuery();
                    if(rowsEffected == 1)
                    {
                        result = true;
                    }
                  

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
           
        }
        public Tournament GetTournament(int tournamentId)
        {
            Tournament tournament = new Tournament();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetTournaments, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                       tournament = ConvertReaderToTournament(reader);
                        

                    }
                    
                    {
                        tournament.NumberOfParticipants = GetNumberOfParticipants(tournament.TournamentId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tournament;
        }
    }
}
