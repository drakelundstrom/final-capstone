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
        //  Drake edit for demo tournament
        List<Participant> GetParticipantsInTournament(int tournamentId);
        // Drake edit for demo tournament
        bool ShuffleTournamentParticipantOrder(int tournamentId);


    }
    
}
