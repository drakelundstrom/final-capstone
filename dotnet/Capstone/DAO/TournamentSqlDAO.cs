using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            "JOIN sports s ON s.sport_id = t.sport_id " +
            "ORDER BY tournament_id;";

        private string sqlCreateTournament = " INSERT INTO tournaments(creator_id , tournament_name , sport_id ) VALUES(" +
            "(SELECT user_id FROM users WHERE username = (@creatorUsername)) " +
            ", (@tournamentName), " +
"(SELECT sport_id FROM sports WHERE sport_name = (@sportName)));";

        private string sqlGetTournament = " SELECT * FROM tournaments t " +
        "JOIN users u ON u.user_id = t.creator_id " +
        "JOIN sports s ON s.sport_id = t.sport_id " +
        "WHERE tournament_id = (@tournament_id);";

        private string sqlGetUsersInTournament = "SELECT u.user_id, username, team_number  FROM users u " +
        "JOIN participants p on p.user_id = u.user_id " +
        "WHERE tournament_id = (@tournament_id) " +
        "ORDER BY team_number;";

        private string sqlUpdateTeamNumber = "UPDATE participants " +
        "SET team_number = (@teamNumber) " +
        "WHERE user_id = (@userId) and tournament_id = (@tournamentId);";

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
                        tournament.NumberOfMatches = CalculateNumberOfMatches(tournament.NumberOfParticipants);
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
            tournament.TournamentStatus = Convert.ToString(reader["tour_status"]);
            tournament.MaxNumberParticipants = Convert.ToInt32(reader["max_number_participants"]);
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
                    if (rowsEffected == 1)
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
                    SqlCommand cmd = new SqlCommand(sqlGetTournament, conn);
                    cmd.Parameters.AddWithValue("@tournament_id", tournamentId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        tournament = ConvertReaderToTournament(reader);


                    }

                    {
                        tournament.NumberOfParticipants = GetNumberOfParticipants(tournament.TournamentId);
                        tournament.NumberOfMatches = CalculateNumberOfMatches(tournament.NumberOfParticipants);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tournament;
        }

        // Drake edit for demo tournament
        private int CalculateNumberOfMatches(int numberOfTeams)
        {
            int result = 0;
            if (numberOfTeams > 0)
            {
                result = numberOfTeams - 1;
            }
            return result;
            /*
            int result = 0;
            int twoCounter = -1;
            while (numberOfTeams >= (Math.Pow(2, twoCounter)))
            {
                twoCounter++;
            }
            result += numberOfTeams - (int)(Math.Pow(2, (twoCounter)));
            for (int i = 0; i < twoCounter; i++)
            {
                result += (int)(Math.Pow(2, i));
            }
            return result; */
        }
        //  Drake edit for demo tournament
        public List<Participant> GetParticipantsInTournament(int tournamentId)
        {
            List<Participant> result = new List<Participant>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetUsersInTournament, conn);
                    cmd.Parameters.AddWithValue("@tournament_id", tournamentId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Participant participant = ConvertReaderToParticipant(reader);
                        participant.TournamentId = tournamentId;
                        result.Add(participant);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        //  Drake edit for demo tournament
        private Participant ConvertReaderToParticipant(SqlDataReader reader)
        {
            Participant participant = new Participant();
            participant.UserId = Convert.ToInt32(reader["user_id"]);
            participant.Username = Convert.ToString(reader["username"]);
            participant.TeamNumber = Convert.ToInt32(reader["team_number"]);
            return participant;
        }

        //  Drake edit for demo tournament
        public bool ShuffleTournamentParticipantOrder(int tournamentId)
        {
            bool result = true;
            List<Participant> original = GetParticipantsInTournament(tournamentId);
            System.Random random = new System.Random();
            List<Participant> shuffledList = original.OrderBy(x => random.Next()).ToList();
            for (int i = 0; i < shuffledList.Count; i++)
            {
                bool interumResult = UpdateTeamNumber(tournamentId, shuffledList[i].UserId, i + 1);
                if (!interumResult)
                {
                    result = interumResult;
                }
            }


            return result;
        }

        //  Drake edit for demo tournament
        private bool UpdateTeamNumber(int tournamentId, int userId, int newTeamNumber)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int rowsEffected = 0;
                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlUpdateTeamNumber, conn);
                    cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@teamNumber", newTeamNumber);
                    rowsEffected = cmd.ExecuteNonQuery();

                    if (rowsEffected == 1)
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

        public bool JoinParticipant(Participant participant)
        {
            bool result = false;

            int newTeamNumber = GetNumberOfParticipants(participant.TournamentId) + 1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int rowsEffected = 0;
                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("INSERT INTO participants(tournament_id, user_id, team_number) VALUES((@tournamentId), (@userId), (@teamNumber));", conn);
                    cmd.Parameters.AddWithValue("@tournamentId", participant.TournamentId);
                    cmd.Parameters.AddWithValue("@userId", participant.UserId);
                    cmd.Parameters.AddWithValue("@teamNumber", newTeamNumber);
                    rowsEffected = cmd.ExecuteNonQuery();

                    if (rowsEffected == 1)
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

            //UPDATE tournaments SET tour_status = (@tournamentStatus) WHERE tournament_id = (@tournamentId);//
        }
        public bool ChangeTournamentStatus(Tournament tournament)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int rowsEffected = 0;
                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("UPDATE tournaments SET tour_status = (@tournamentStatus) WHERE tournament_id = (@tournamentId);", conn);
                    cmd.Parameters.AddWithValue("@tournamentId", tournament.TournamentId);
                    cmd.Parameters.AddWithValue("@tournamentStatus", tournament.TournamentStatus);
                    rowsEffected = cmd.ExecuteNonQuery();


                    if (rowsEffected == 1)
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

        //SELECT creator_id FROM tournaments WHERE tournament_id = (1);//
        public int TournamentOwner(int tournamentId)
        {
            int result = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int rowsEffected = 0;
                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("SELECT creator_id FROM tournaments WHERE tournament_id = (@tournamentId);", conn);
                    cmd.Parameters.AddWithValue("@tournamentId", tournamentId);

                    result = Convert.ToInt32(cmd.ExecuteScalar());


                 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;

        }

    }
}
