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


        private string sqlGetMatchesInTournament = "SELECT DISTINCT m.tournament_id, match_number, " +
 "home_team_id, home_team_score,  home.team_number AS 'home_team_number'  , home_users.username AS 'home_name', " +
 " away_team_id, away_team_score, away.team_number AS 'away_team_number'  , away_users.username AS 'away_name', " +
 "victor_id, victor.team_number AS 'victor_team_number'  , victor_users.username AS 'victor_name' " +
 " FROM matches m " +
 " JOIN participants away ON (away.user_id = m.away_team_id  and away.tournament_id = m.tournament_id) " +
 " JOIN users away_users ON away_users.user_id = m.away_team_id " +
 " JOIN participants home ON (home.user_id = m.home_team_id  and home.tournament_id = m.tournament_id) " +
 " JOIN users home_users ON home_users.user_id = m.home_team_id " +
 " JOIN participants victor ON (victor.user_id = m.victor_id  and victor.tournament_id = m.tournament_id) " +
 " JOIN users victor_users ON victor_users.user_id = m.victor_id " +
 " WHERE m.tournament_id = (@tournament_id) " +
 " ORDER BY match_number;";

        private string sqlGetTournamentsByCreator = "SELECT * FROM tournaments t " +
        "JOIN users u ON u.user_id = t.creator_id " +
        "JOIN sports s ON s.sport_id = t.sport_id " +
        "WHERE t.creator_id = (@creatorId);";

        private string sqlGetTournamentsByParticipant = " SELECT * FROM tournaments t  " +
        "JOIN users u ON u.user_id = t.creator_id " +
        "JOIN sports s ON s.sport_id = t.sport_id " +
        " WHERE tournament_id IN (SELECT tournament_id " +
                          "  FROM participants " +
                          " WHERE user_id = (@userId));";


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


        public List<Match> GetMatches(int tournamentId)
        {
            List<Match> matches = new List<Match>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetMatchesInTournament, conn);
                    cmd.Parameters.AddWithValue("@tournament_id", tournamentId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Match match = ConvertReaderToMatch(reader);
                        matches.Add(match);


                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Match match = new Match();
                match.MatchNumber = -1;
                matches.Add(match);
            }
            return matches;
        }


        private Match ConvertReaderToMatch(SqlDataReader reader)
        {
            Match match = new Match();
            match.TournamentId = Convert.ToInt32(reader["tournament_id"]);
            match.MatchNumber = Convert.ToInt32(reader["match_number"]);

            match.HomeTeamId = Convert.ToInt32(reader["home_team_id"]);
            match.HomeTeamScore = Convert.ToString(reader["home_team_score"]);
            match.HomeTeamNumber = Convert.ToInt32(reader["home_team_number"]);
            match.HomeTeamName = Convert.ToString(reader["home_name"]);

            match.AwayTeamId = Convert.ToInt32(reader["away_team_id"]);
            match.AwayTeamScore = Convert.ToString(reader["away_team_score"]);
            match.AwayTeamNumber = Convert.ToInt32(reader["away_team_number"]);
            match.AwayTeamName = Convert.ToString(reader["away_name"]);

            match.VictorTeamId = Convert.ToInt32(reader["victor_id"]);
            match.VictorTeamNumber = Convert.ToInt32(reader["victor_team_number"]);
            match.VictorTeamName = Convert.ToString(reader["victor_name"]);

            return match;
        }

        public List<Tournament> GetTournamentsByCreator(int creatorId)
        {
            List<Tournament> tournaments = new List<Tournament>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetTournamentsByCreator, conn);
                    cmd.Parameters.AddWithValue("@creatorId", creatorId);
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
                Tournament tournament = new Tournament();
                tournament.TournamentId = -1;
                tournaments.Add(tournament);
            }
            return tournaments;
        }

        public List<Tournament> GetTournamentsByParticipant(int userId)
        {
            List<Tournament> tournaments = new List<Tournament>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand(sqlGetTournamentsByParticipant, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
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
                Tournament tournament = new Tournament();
                tournament.TournamentId = -1;
                tournaments.Add(tournament);
            }
            return tournaments;
        }

        public bool IsTournamentCompleted(int tournamentId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("SELECT tour_status FROM tournaments WHERE tournament_id = (@tournamentId)", conn);
                    cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                    string status = Convert.ToString(cmd.ExecuteScalar());

                    if (status.ToLower() == "completed")
                    {
                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = true;
            }

            return result;
        }

        public List<Participant> GetBracketLocations(int tournamentId)
        {
            List<Participant> result = new List<Participant>();
            List<Participant> teams = GetParticipantsInTournament(tournamentId);
            Tournament tournament = GetTournament(tournamentId);
            List<Match> matches = GetMatches(tournamentId);

            for (int i = 1; i < 16; i++)
            {
                Participant participant = new Participant();
                if (i == 1)
                {

                    if (teams.Count == 0)
                    {
                        participant.Username = "";
                    }
                    else if (teams.Count == 1)
                    {
                        participant.Username = teams[0].Username;
                    }
                    else if (matches.Count == tournament.NumberOfMatches)
                    {
                        participant.Username = matches[matches.Count - 1].VictorTeamName;
                    }
                    else
                    {
                        participant.Username = "";
                    }
                }
                else
                {
                    if ((i) > (2 * teams.Count - 1))
                    {
                        participant.Username = "";
                    }
                    else if ((i - tournament.NumberOfMatches) <= teams.Count && (i - tournament.NumberOfMatches) >0)
                    {
                        participant.Username = teams[i - tournament.NumberOfMatches-1].Username;
                    }
                    else
                    {
                        participant.Username = "";
                        switch (i)
                        {
                            case 2:
                                if (matches.Count >= tournament.NumberOfMatches - 1)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 3].VictorTeamName;
                                }
                                break;
                            case 3:
                                if (matches.Count >= tournament.NumberOfMatches - 1)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 2].VictorTeamName;
                                }
                                break;
                            case 4:
                                if (matches.Count >= tournament.NumberOfMatches - 3)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 7].VictorTeamName;
                                }
                                break;
                            case 5:
                                if (matches.Count >= tournament.NumberOfMatches - 4)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 6].VictorTeamName;
                                }
                                break;
                            case 6:
                                if (matches.Count >= tournament.NumberOfMatches - 4)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 5].VictorTeamName;
                                }
                                break;
                            case 7:
                                if (matches.Count >= tournament.NumberOfMatches - 3)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 4].VictorTeamName;
                                }
                                break;
                          /*  case 8:
                                if (matches.Count >= tournament.NumberOfMatches - 14)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 15].VictorTeamName;
                                }
                                break;
                            case 9:
                                if (matches.Count >= tournament.NumberOfMatches - 13)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 14].VictorTeamName;
                                }
                                break;
                            case 10:
                                if (matches.Count >= tournament.NumberOfMatches - 12)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 13].VictorTeamName;
                                }
                                break;
                            case 11:
                                if (matches.Count >= tournament.NumberOfMatches - 11)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 12].VictorTeamName;
                                }
                                break;
                            case 12:
                                if (matches.Count >= tournament.NumberOfMatches - 10)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 9].VictorTeamName;
                                }
                                break;
                            case 13:
                                if (matches.Count >= tournament.NumberOfMatches - 9)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 8].VictorTeamName;
                                }
                                break;
                            case 14:
                                if (matches.Count >= tournament.NumberOfMatches - 8)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 7].VictorTeamName;
                                }
                                break;
                            case 15:
                                if (matches.Count >= tournament.NumberOfMatches - 7)
                                {
                                    participant.Username = matches[tournament.NumberOfMatches - 6].VictorTeamName;
                                }
                                break; */
                        }
                    }

                }

                result.Add(participant);
            }
            return result;
        }
    }
}

