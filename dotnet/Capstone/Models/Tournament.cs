using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public int CreatorId { get; set; }
        public string CreatorUsername { get; set; }

        public string TournamentName { get; set; }
        public int SportId { get; set; }

        public string SportName { get; set; }

        public string TournamentStaus { get; set; }

        public int NumberOfParticipants { get; set; }

        public int NumberOfMatches { get; set; }

    }
}
