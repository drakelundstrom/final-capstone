using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.Security;
using Capstone.DAO.Interfaces;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Capstone.DAO;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentDAO tournamentDAO;

        public TournamentController (ITournamentDAO _tournamentDAO)
        {
            tournamentDAO = _tournamentDAO;
        }


        [AllowAnonymous]
        [HttpGet()]
        public ActionResult<List<Tournament>> GetAllTournaments()
        {
            List<Tournament> tournaments = tournamentDAO.GetTournaments();
            if (tournaments.Count != 0)
            {
                return Ok(tournaments);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost()]
        public ActionResult CreateTournament(Tournament tournament)
        {
            bool result = tournamentDAO.CreateTournament(tournament);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [AllowAnonymous]
        [HttpGet("{tournamentId}")]
        public ActionResult<Tournament> GetTournament(int tournamentId)
        {
            Tournament tournament = tournamentDAO.GetTournament(tournamentId);
            if (tournament != null)
            {
                return Ok(tournament);
            }
            else
            {
                return NotFound();
            }
        }
        //  Drake edit for demo tournament
        [AllowAnonymous]
        [HttpGet("participants/{tournamentId}")]
        public ActionResult<List<Participant>> GetParticipantsInTournament(int tournamentId)
        {
            List<Participant> participants = tournamentDAO.GetParticipantsInTournament(tournamentId);
            if (participants != null)
            {
                return Ok(participants);
            } 
            else
            {
                return NotFound();
            }
        }
        //  Drake edit for demo tournament
        [Authorize(Roles = "admin")]
        [HttpPost("shuffle/{tournamentId}")]
        public ActionResult CreateTournament(int tournamentId)
        {
            bool result = tournamentDAO.ShuffleTournamentParticipantOrder(tournamentId);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [Authorize()]
        [HttpPost("join")]
        public ActionResult JoinParticipant(Participant participant)
        {
            bool result = tournamentDAO.JoinParticipant(participant);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }


    }
}
