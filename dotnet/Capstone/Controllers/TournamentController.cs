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
    }
}
