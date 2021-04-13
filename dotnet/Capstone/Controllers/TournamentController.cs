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

        public TournamentController(ITournamentDAO _tournamentDAO)
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
            if ((tournament != null) && (tournament.TournamentId != 0))
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

            if (!(IsCorrectAdmin(tournamentId)))
            {
                return Unauthorized();
            }

            if (tournamentDAO.IsTournamentCompleted(tournamentId))
            {
                return Forbid();
            }

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
            if (tournamentDAO.IsTournamentCompleted(participant.TournamentId))
            {
                return Forbid();
            }

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }
        [Authorize(Roles = "admin")]
        [HttpPost("changeStatus")]
        public ActionResult ChangeStatus(Tournament tournament)
        {
            if (!(IsCorrectAdmin(tournament.TournamentId)))
            {
                return Unauthorized();
            }
            if (tournamentDAO.IsTournamentCompleted(tournament.TournamentId))
            {
                return Forbid();
            }

            bool result = tournamentDAO.ChangeTournamentStatus(tournament);



            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }

        private bool IsCorrectAdmin(int tournamentId)
        {
            bool result = false;
            int userId = int.Parse(User.FindFirst("sub").Value);
            if (userId == tournamentDAO.TournamentOwner(tournamentId))
            {
                result = true;
            }

            return result;
        }

        [AllowAnonymous]
        [HttpGet("matches/{tournamentId}")]
        public ActionResult<List<Match>> GetMatches(int tournamentId)
        {
            List<Match> matches = tournamentDAO.GetMatches(tournamentId);
            if (matches.Count >= 1)
            {
                if (matches[0].MatchNumber == -1)
                {
                    return NotFound();
                }

            }
            return Ok(matches);
        }

        [Authorize()]
        [HttpGet("creator")]
        public ActionResult<List<Tournament>> GetTournamentsByCreator()
        {

            int userId = int.Parse(User.FindFirst("sub").Value);
            List<Tournament> tournaments = tournamentDAO.GetTournamentsByCreator(userId);
            if (tournaments.Count >= 1)
            {
                if (tournaments[0].TournamentId == -1)
                {
                    return NotFound();
                }

            }

            {
                return Ok(tournaments);
            }
        }
        [Authorize()]
        [HttpGet("participant")]
        public ActionResult<List<Tournament>> GetTournamentsByParticipant()
        {

            int userId = int.Parse(User.FindFirst("sub").Value);
            List<Tournament> tournaments = tournamentDAO.GetTournamentsByParticipant(userId);
            if (tournaments.Count >= 1)
            {
                if (tournaments[0].TournamentId == -1)
                {
                    return NotFound();
                }

            }

            {
                return Ok(tournaments);
            }
        }

        [AllowAnonymous]
        [HttpGet("fillbracket/{tournamentId}")]
        public ActionResult<List<Participant>> GetBracketLocations(int tournamentId)
        {
            List<Participant> participants = tournamentDAO.GetBracketLocations(tournamentId);
            if (participants.Count == 0)
            {
                return NotFound();


            }
            return Ok(participants);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("getNextMatch/{tournamentId}")]
        public ActionResult GetNextMatch(int tournamentId)
        {
            if (!(IsCorrectAdmin(tournamentId)))
            {
                return Unauthorized();
            }
            if (!(tournamentDAO.IsTournamentCompleted(tournamentId)))
            {
                return Forbid();
            }

            Match match = tournamentDAO.GetNextMatch(tournamentId);

            if (match.MatchNumber == -1)
            {
                return NotFound();
            }
            return Ok(match);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addNextMatch/")]
        public ActionResult AddNextMatch(Match match)
        {
            if (!(IsCorrectAdmin(match.TournamentId)))
            {
                return Unauthorized();
            }
            if (!(tournamentDAO.IsTournamentCompleted(match.TournamentId)))
            {
                return Forbid();
            }

            bool result = tournamentDAO.AddNextMatch(match);

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
