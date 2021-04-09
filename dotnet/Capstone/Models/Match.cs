using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Match
    {
        public int TournamentId { get; set; }
        public int MatchNumber { get; set; }

        public int HomeTeamId { get; set; }
        public string HomeTeamScore { get; set; }
        public int HomeTeamNumber { get; set; }
        public string HomeTeamName { get; set; }

        public int AwayTeamId { get; set; }
        public string AwayTeamScore { get; set; }
        public int AwayTeamNumber { get; set; }
        public string AwayTeamName { get; set; }

        public int VictorTeamId { get; set; }
        public int VictorTeamNumber { get; set; }
        public string VictorTeamName { get; set; }

    }
}
