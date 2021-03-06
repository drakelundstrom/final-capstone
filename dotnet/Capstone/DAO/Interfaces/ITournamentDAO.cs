using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface ITournamentDAO
    {
        List<Tournament> GetTournaments();
        public bool CreateTournament(Tournament tournament);
        public Tournament GetTournament(int tournamentId);
        List<Participant> GetParticipantsInTournament(int tournamentId);
        bool ShuffleTournamentParticipantOrder(int tournamentId);
        bool JoinParticipant(Participant participant);
        bool ChangeTournamentStatus(Tournament tournament);
        int TournamentOwner(int tournamentId);
        List<Match> GetMatches(int tournamentId);
        List<Tournament> GetTournamentsByCreator(int creatorId);
        List<Tournament> GetTournamentsByParticipant(int userId);
        bool IsTournamentCompleted(int tournamentId);
        bool IsTournamentActive(int tournamentId);
        bool IsTournamentRecruiting(int tournamentId);
        List<Participant> GetBracketLocations(int tournamentId);
        Match GetNextMatch(int tournamentId);
        bool AddNextMatch(Match match);
        bool EraseMatchesInTournament(int tournamentId);
    }
    
}
